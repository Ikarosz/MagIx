
//using UnityEngine;
//using UnityEngine.UI;
//namespace MagIx
//{
//    public class interakcoseszközök1 : MonoBehaviour
//    {
//        public float radius = 3;

//        bool isFocus = false;
//        public GameObject játekos;
//        public float tavolsag;
      
//        private JatekosStat jatekosstat;
 
//        private Szoba szobaspawn = new Szoba();
//        //  public GameObject szoba;

        
//        public GameObject kiir;
//        public Transform szobahely;
//        public GameObject padlo;
//        public GameObject fal1;
//        public GameObject fal2;
//        public GameObject fal3;
//        public GameObject e;
//        public GameObject inttargy;



//        private void Start()
//        {
//            kiir = GameObject.Find("E");
//            kiir.SetActive(false);
//            játekos = GameObject.Find("ThirdPersonController");

//            padlo = GameObject.Find("padlo");
//            fal1 = GameObject.Find("1tpifal");
//            fal2 = GameObject.Find("1tpifal");
//            fal3 = GameObject.Find("1tpifal");
//            inttargy = GameObject.FindWithTag("ajto");

//          //  e = inttargy.gameObject;
//           // szobahely = this.gameObject.transform;
//        }

//        private void Update()
//        {
//            Debug.Log(kiir.name);
//            tavolsag = Vector3.Distance(játekos.transform.position, inttargy.transform.position);
//            //  Debug.Log(tavolsag + " " + radius);

//            Debug.Log(játekos.name + ": " + játekos.transform.position + ", " + this.name + ": " + this.transform.position + ", Táv:" + tavolsag);

//            if (tavolsag <= radius)
//            {
//                Debug.Log("benne");
//                kiir.SetActive(true);
//               // kiir.text = "E";


//                if (Input.GetButtonUp("E"))
//                {
//                    Debug.Log("" + szobahely + "bennev vagyok");

//                    //jatekosstat.arany+=1;
//                   //kiir.text = "";
//                    // Destroy(inttargy);


//                    szobaspawn.Spawn(padlo, fal1, fal2, fal3,  szobahely);
//                    Debug.Log("destroy");

//                    inttargy.SetActive(false);
//                    Debug.Log("destroy2");
//                }



//            }
//            //else
//                ////GameObject.
//                //kiir = GameObject.find FindGameObjectsWithTag("Respawn");
//                //kiir.text = "";




//            //public void onFocused(Transform jatekosTransform)
//            //{
//            //    isFocus = true;
//            //    játekos = jatekosTransform;
//            //}

//            //public void onDeFocused()
//            //{
//            //    isFocus = false;
//            //    játekos = null;
//            //}
//        }
//        private void OnDrawGizmosSelected()
//        {
//            Gizmos.color = Color.yellow;
//            Gizmos.DrawWireSphere(inttargy.transform.position, radius);
//        }

//    }

//    //public bool Interakció()
//    //{
//    //    tavolsag = Vector3.Distance(játekos.position, transform.position);
//    //    if (tavolsag <= radius)
//    //    {

//    //        kiir.text = "E";
//    //        if (Input.GetButtonUp("E"))
//    //        {

//    //            jatekosstat.arany += 1;
//    //            kiir.text = "";
//    //            // Destroy(inttargy);




//    //        }



//    //    }
//    //    else
//    //        kiir.text = "";



//    //    return yes;
//    //}

//}