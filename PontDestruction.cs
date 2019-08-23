using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MagIx
{
    public class PontDestruction : MonoBehaviour
    {

        public GameObject Jatekosok;
        public GameObject Koveto;



        void Start()
        {
            
            Jatekosok = GameObject.Find("ThirdPersonController");

           
            // Debug.Log(Koveto + "boosternelkoveto" +
            //        "");
        }


        void Update()
        {

        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject == Jatekosok)
            {

                Jatekosok.transform.GetChild(5).gameObject.SetActive(true);
                Debug.Log(Jatekosok.transform.GetChild(5)+"follower");
               // Koveto.SetActive(true);
                this.gameObject.SetActive(false);






            }

        }


        IEnumerator WaitForSeconds()
        {
            yield return new WaitForSeconds(5);
            this.gameObject.SetActive(true);
        }




    }

}