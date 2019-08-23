using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MagIx
{
    public class ujrageneral : MonoBehaviour
{

        public float radius = 3;

        bool isFocus = false;
        public GameObject játekos;
        public float tavolsag;

        private JatekosStat jatekosstat;
        // public GameObject inttargy;
        private Szoba szobaletrehoz = new Szoba();
        //  public GameObject szoba;

        public GameObject kiir;
        Jatekosok jatekosadat;
        public GameObject main;
    
        private void Start()
        {
           
           
            

            játekos = GameObject.Find("ThirdPersonController");
            GameObject jatekoshud = GameObject.Find("játékosHUD");
            kiir = jatekoshud.transform.Find("E").gameObject;
            main = GameObject.Find("Main");
            
            jatekosadat = main.GetComponent<Jatekosok>();

        }

        private void Update()
        {
            // Debug.Log(kiir.name);
            tavolsag = Vector3.Distance(játekos.transform.position, this.transform.position);
            //  Debug.Log(tavolsag + " " + radius);

            //Debug.Log(játekos.name + ": " + játekos.transform.position + ", " + this.name + ": " + this.transform.position + ", Táv:" + tavolsag);

            if (tavolsag <= radius)
            {

                kiir.SetActive(true);



                if (Input.GetButtonUp("E"))
                {
                    jatekosadat.Adatokfel();
                  

                    Destroy(this);
                    SceneManager.LoadScene(2);
                 
                }




            }

        }
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }

    }

    //public bool Interakció()
    //{
    //    tavolsag = Vector3.Distance(játekos.position, transform.position);
    //    if (tavolsag <= radius)
    //    {

    //        kiir.text = "E";
    //        if (Input.GetButtonUp("E"))
    //        {

    //            jatekosstat.arany += 1;
    //            kiir.text = "";
    //            // Destroy(inttargy);




    //        }



    //    }
    //    else
    //        kiir.text = "";



    //    return yes;
    //}

}