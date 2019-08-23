
using UnityEngine;
using UnityEngine.UI;
namespace MagIx
{
    public class interakcoseszközök : MonoBehaviour
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
        public Transform szobahely;
        public GameObject padlo;
        public GameObject fal1;
        public GameObject fal2;
        public GameObject fal3;
        public GameObject e;
        public GameObject ellenség;
        public GameObject pont;

        private void Start()
        {
            kiir = GameObject.Find("E");
            kiir.SetActive(false);
            játekos = GameObject.Find("ThirdPersonController");
          padlo = GameObject.Find("padlo");
            fal1 = GameObject.Find("1tpifal");
            fal2 = GameObject.Find("2tipfal");
            fal3 = GameObject.Find("2tipfal");
            pont = GameObject.Find("Pont1");
            //ellenség = GameObject.Find("Ethan(3)"); 

            e = this.gameObject;
           // szobahely = this.gameObject.transform;
        }

        private void Update()
        {
           // Debug.Log(kiir.name);
            tavolsag = Vector3.Distance(játekos.transform.position, this.transform.position);
            //  Debug.Log(tavolsag + " " + radius);

            //Debug.Log(játekos.name + ": " + játekos.transform.position + ", " + this.name + ": " + this.transform.position + ", Táv:" + tavolsag);

            if (tavolsag <= radius)
            {
                //Debug.Log("benne");
                kiir.SetActive(true);
               // kiir.text = "E";


                if (Input.GetButtonUp("E"))
                {
                   // Debug.Log("" + szobahely + "bennev vagyok");

                    //jatekosstat.arany+=1;
                   //kiir.text = "";
                    // Destroy(inttargy);


                    szobaletrehoz.szobaletrehoz(padlo, fal1, fal2, fal3,  szobahely);
                   // Debug.Log("destroy");

                    e.SetActive(false);
                  //  Debug.Log("destroy2");

                    szobaletrehoz.töltelék(ellenség,pont, szobahely);
                }
               



            }
            //else
                ////GameObject.
                //kiir = GameObject.find FindGameObjectsWithTag("Respawn");
                //kiir.text = "";




            //public void onFocused(Transform jatekosTransform)
            //{
            //    isFocus = true;
            //    játekos = jatekosTransform;
            //}

            //public void onDeFocused()
            //{
            //    isFocus = false;
            //    játekos = null;
            //}
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