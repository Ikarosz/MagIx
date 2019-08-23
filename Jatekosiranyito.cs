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
            //fõ kamera kiválasztása
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



        // A fix frissítést a fizikával szinkronban hívják
        private void FixedUpdate()
        {
          
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            float v = CrossPlatformInputManager.GetAxis("Vertical");
            bool gugol = Input.GetKey(KeyCode.C);


            // kiszámolja az áthaladási irányt a karakterhez
            if (kamera != null)
            {

                // a kamera relatív irányának kiszámításához mozgassa:
                mozgas_kameraelore = Vector3.Scale(kamera.forward, new Vector3(1, 0, 1)).normalized;
                mozgas = v*mozgas_kameraelore + h*kamera.right;
            }
            else
            {
                
                //nem a fõ kamerák esetében a világ relatív irányait használjuk
                mozgas = v*Vector3.forward + h*Vector3.right;
            }

			// sét sebesség
	        if (Input.GetKey(KeyCode.LeftShift)) mozgas *= 0.5f;


        
           // átadja az összes paramétert a karaktervezérlõ szkripthez
            Karakter.Move(mozgas, gugol, ugras);
            ugras = false;
        }
    }
}
