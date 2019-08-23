
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace MagIx
{
    public class Falnyit : MonoBehaviour
    {
        public float radius = 3;

       
        public GameObject játekos;
        public float tavolsag;
        private Vector3 kezdopozicio;
        public float tavolsagmozgat = 5f;
        public GameObject kiir;

        bool nyit;

        private void Start()
        {
         
            játekos = GameObject.Find("ThirdPersonController");
          GameObject jatekoshud = GameObject.Find("játékosHUD");
            kiir = jatekoshud.transform.Find("E").gameObject;
            kezdopozicio = this.transform.position;
            nyit = false;

        }

        private void Update()
        {
            

            tavolsag = Vector3.Distance(játekos.transform.position, this.transform.position);


            if (tavolsag <= radius )
            {

                //kiir.SetActive(true);



                //if (Input.GetButtonUp("E"))
                //{


                //    Destroy(this);


                //}
                //while (kiir.active )
                //{
                //    Input.GetButtonUp("E")
                //    kiir.SetActive(true);
                //}
                if (Input.GetButtonUp("E") && nyit==false)
                {
                    nyit = true;
                    while (tavolsagmozgat > (kezdopozicio.y - transform.position.y)) { 

                    transform.Translate(Vector3.down * Time.deltaTime, Space.World);
                }

                    nyit = false;
                }
            }
            else
            {
                
                kiir.SetActive(false);
            }
            kiir.SetActive(false);
   









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