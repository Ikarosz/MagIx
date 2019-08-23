using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (Jatekoskarakteralap))]
    public class Jatekosiranyito : MonoBehaviour
    {
        private Jatekoskarakteralap Karakter; // A reference to the ThirdPersonCharacter on the object
        public Transform kamera;
       // A reference to the main camera in the scenes transform
        private Vector3 mozgas_kameraelore;             // The current forward direction of the camera
        private Vector3 mozgas;
        private bool ugras;                      // the world-relative desired move direction, calculated from the camForward and user input.

        
        private void Start()
        {
            //f� kamera kiv�laszt�sa
            if (Camera.main != null)
            {
                kamera = Camera.main.transform;
            }
           

                Karakter = GetComponent<Jatekoskarakteralap>();
        }


        private void Update()
        {
            if (!ugras)
            {
                ugras = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }



        // A fix friss�t�st a fizik�val szinkronban h�vj�k
        private void FixedUpdate()
        {
          
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool gugol = Input.GetKey(KeyCode.C);


            // kisz�molja az �thalad�si ir�nyt a karakterhez
            if (kamera != null)
            {

                // a kamera relat�v ir�ny�nak kisz�m�t�s�hoz mozgassa:
                mozgas_kameraelore = Vector3.Scale(kamera.forward, new Vector3(1, 0, 1)).normalized;
                mozgas = v*mozgas_kameraelore + h*kamera.right;
            }
            else
            {
                
                //nem a f� kamer�k eset�ben a vil�g relat�v ir�nyait haszn�ljuk
                mozgas = v*Vector3.forward + h*Vector3.right;
            }

			// s�t sebess�g
	        if (Input.GetKey(KeyCode.LeftShift)) mozgas *= 0.5f;


        
           // �tadja az �sszes param�tert a karaktervez�rl� szkripthez
            Karakter.Move(mozgas, gugol, ugras);
            ugras = false;
        }
    }
}
