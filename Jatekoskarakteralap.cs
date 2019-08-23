using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
	[RequireComponent(typeof(Rigidbody))]
	[RequireComponent(typeof(CapsuleCollider))]
	[RequireComponent(typeof(Animator))]
	public class Jatekoskarakteralap : MonoBehaviour
	{
		[SerializeField] float fordulas = 360;
		[SerializeField] float helyhezfordul = 180;
		[SerializeField] float ugrasero = 12f;
		[Range(1f, 4f)][SerializeField] float gravitacioero = 2f;
		[SerializeField] float m_RunCycleLegOffset = 0.2f; //specific to the character in sample assets, will need to be modified to work with others
		[SerializeField] float mozgassebesseg = 1f;
		[SerializeField] float animaciosevesseg = 1f;
		[SerializeField] float foldvizsgaltavolsag = 20f;

		Rigidbody Rigidbody;
		Animator Animal;
		bool földönvan;
		float eredetifoldvizsgal;
		const float k_Half = 0.5f;
		float fordulmenyniseg;
		float eloremennyiseg;
		Vector3 fold;
		float vazmagassag;
		Vector3 vazkozep;
		CapsuleCollider Vaz;
		bool gugolas;


		void Start()
		{
			Animal = GetComponent<Animator>();
			Rigidbody = GetComponent<Rigidbody>();
			Vaz = GetComponent<CapsuleCollider>();
			vazmagassag = Vaz.height;
			vazkozep = Vaz.center;

			Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
			eredetifoldvizsgal = foldvizsgaltavolsag;
		}


		public void Move(Vector3 move, bool crouch, bool jump)
		{

            // a világ relatív mozgásbeviteli vektorját helyi relatívvá alakítja
// fordítsuk be a kívánt mennyiséget és a szükséges mennyiséget előre
// irány.
            if (move.magnitude > 1f) move.Normalize();
			move = transform.InverseTransformDirection(move);
			foldstatusz();
			move = Vector3.ProjectOnPlane(move, fold);
			fordulmenyniseg = Mathf.Atan2(move.x, move.z);
			eloremennyiseg = move.z;

			Extraforgás();


            // a vezérlés és a sebesség kezelése eltérő, ha földelön van vagy a levegőben és levegő:
            if (földönvan)
			{
				allapotvaltozaskezelese(crouch, jump);
			}
			else
			{
				levegobenmozgas();
			}

			vazvizsgalgugolashoz(crouch);
			johelyenfelall();

            // küldjön bemeneti és egyéb állapotparamétereket az animátornak
            UpdateAnimator(move);
		}


		void vazvizsgalgugolashoz(bool gugol)
		{
			if (földönvan && gugol)
			{
				if (gugolas) return;
				Vaz.height = Vaz.height / 2f;
				Vaz.center = Vaz.center / 2f;
				gugolas = true;
			}
			else
			{
				Ray gugolRay = new Ray(Rigidbody.position + Vector3.up * Vaz.radius * k_Half, Vector3.up);
				float crouchRayLength = vazmagassag - Vaz.radius * k_Half;
				if (Physics.SphereCast(gugolRay, Vaz.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
				{
					gugolas = true;
					return;
				}
				Vaz.height = vazmagassag;
				Vaz.center = vazkozep;
				gugolas = false;
			}
		}

		void johelyenfelall()
		{

            // megakadályozza, hogy csak a zónákban álljon fel
            if (!gugolas)
			{
				Ray crouchRay = new Ray(Rigidbody.position + Vector3.up * Vaz.radius * k_Half, Vector3.up);
				float crouchRayLength = vazmagassag - Vaz.radius * k_Half;
				if (Physics.SphereCast(crouchRay, Vaz.radius * k_Half, crouchRayLength, Physics.AllLayers, QueryTriggerInteraction.Ignore))
				{
					gugolas = true;
				}
			}
		}


		void UpdateAnimator(Vector3 move)
		{
            // frissítse az animátor paramétereit
            Animal.SetFloat("Forward", eloremennyiseg, 0.1f, Time.deltaTime);
			Animal.SetFloat("Turn", fordulmenyniseg, 0.1f, Time.deltaTime);
			Animal.SetBool("Crouch", gugolas);
			Animal.SetBool("OnGround", földönvan);
			if (!földönvan)
			{
				Animal.SetFloat("Jump", Rigidbody.velocity.y);
			}

            // számítsuk ki, hogy melyik láb van hátra, hogy hagyja ezt a lábat az ugrás animációban
            // (Ez a kód az adott futási ciklus eltolásától függ animációinkban,
            // és feltételezi, hogy az egyik láb áthalad a másiknál ​​a 0,0 és 0,5-es normalizált klipidők között
            float runCycle =
				Mathf.Repeat(
					Animal.GetCurrentAnimatorStateInfo(0).normalizedTime + m_RunCycleLegOffset, 1);
			float jumpLeg = (runCycle < k_Half ? 1 : -1) * eloremennyiseg;
			if (földönvan)
			{
				Animal.SetFloat("JumpLeg", jumpLeg);
			}


            // az animációs sebesség szorzó lehetővé teszi a gyaloglás / futás teljes sebességét az ellenőrben,
            // ami a mozgás sebességét befolyásolja a gyökérmozgás miatt.
            if (földönvan && move.magnitude > 0)
			{
				Animal.speed = animaciosevesseg;
			}
			else
			{

                // ne használja ezt a levegőben
                Animal.speed = 1;
			}
		}


		void levegobenmozgas()
		{
            // extra gravitáció :
            Vector3 extragravitáció = (Physics.gravity * gravitacioero) - Physics.gravity;
			Rigidbody.AddForce(extragravitáció);

			foldvizsgaltavolsag = Rigidbody.velocity.y < 0 ? eredetifoldvizsgal : 1f;
		}


		void allapotvaltozaskezelese(bool crouch, bool jump)
		{
            // ellenőrizze, hogy a feltételek megfelelőek-e az ugrás engedélyezéséhez:
            if (jump && !crouch && Animal.GetCurrentAnimatorStateInfo(0).IsName("Grounded"))
			{
				// ugraás!
				Rigidbody.velocity = new Vector3(Rigidbody.velocity.x, ugrasero, Rigidbody.velocity.z);
				földönvan = false;
				Animal.applyRootMotion = false;
				foldvizsgaltavolsag = 0.1f;
			}
		}

		void Extraforgás()
		{
            // segítsen a karakternek gyorsabban fordulni (ez az animáció gyökérforgatásán túl)			
            float turnSpeed = Mathf.Lerp(helyhezfordul, fordulas, eloremennyiseg);
			transform.Rotate(0, fordulmenyniseg * turnSpeed * Time.deltaTime, 0);
		}


		public void OnAnimatorMove()
		{

            // végrehajtjuk ezt a funkciót az alapértelmezett gyökérmozgás felülbírálásához.
            // ez lehetővé teszi, hogy módosítsuk a pozíciósebességet az alkalmazás előtt.
            if (földönvan && Time.deltaTime > 0)
			{
				Vector3 v = (Animal.deltaPosition * mozgassebesseg) / Time.deltaTime;


                // megtartjuk az aktuális sebesség jelenlegi y részét.
                v.y = Rigidbody.velocity.y;
				Rigidbody.velocity = v;
			}
		}


		void foldstatusz()
		{
			RaycastHit hitInfo;
#if UNITY_EDITOR

            // segítő, hogy megjelenítse a helyszíni ellenőrző sugarat a jelenet nézetben
            Debug.DrawLine(transform.position + (Vector3.up * 0.1f), transform.position + (Vector3.up * 0.1f) + (Vector3.down * foldvizsgaltavolsag));
#endif

            // 0.1f egy kis eltolás a sugár elindításához a karakter belsejéből
            // is jó megjegyezni, hogy a mintaeszköz transzformációs pozíciója a karakter alapja
            if (Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, foldvizsgaltavolsag))
			{
				fold = hitInfo.normal;
				földönvan = true;
				Animal.applyRootMotion = true;
			}
			else
			{
				földönvan = false;
				fold = Vector3.up;
				Animal.applyRootMotion = false;
			}
		}
	}
}
