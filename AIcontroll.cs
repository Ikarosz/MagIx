using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace MagIx
    {
        public class AIcontroll : MonoBehaviour
        {
            
           public float táv;
        public GameObject[] Játékos;



        public float tamad;

        public GameObject ellenseg;

        public float CelpontTavolsag;
            public float ellensegNezTavolsag;
            public float EllensegtamadasTavlosag;
            public float elelnsegMozgasSebesseg;
        //public float daming;
        public GameObject Celpont;
        Rigidbody rigid;
        Renderer enReneder;
        public bool tuzel;
        //private int ertek;
        JatekosStat jatekosstat;
        Élet elet;
        public int ertek;
        private bool adottaranyat;

        // Start is called before the first frame update
        void Start()
            {
            adottaranyat = false;
            ertek = 1;
            tuzel = true;
            tamad = -0.5f;
            Celpont = GameObject.Find("ThirdPersonController");
            //getcomponentel masik class fuggvenyhivas, mivel a letezo script kell.
            jatekosstat = Celpont.GetComponent<JatekosStat>();

            elet = gameObject.GetComponent<Élet>();


            //jatekosstat = new JatekosStat();
            //jatekosstat = ScriptableObject.GetComponent<JatekosStat>();
            enReneder = GetComponent<Renderer>();
            rigid = GetComponent<Rigidbody>();
                

                
        }
       void Update()
        {


            rigid.constraints = RigidbodyConstraints.FreezeRotationY;
            //jatekosstat.EletValtoz(-5);

            //FindObjectOfType<JatekosStat>().EletValtoz(-5);
            // JatekosStat.EletValtoz(-5);
            //jatekosstat.EletValtoz(-5);
            rigid.velocity = new Vector3(0, -10, 0);

           // Debug.Log("ellenseg");
            CelpontTavolsag = Vector3.Distance(Celpont.transform.position, ellenseg.transform.position);

            if (CelpontTavolsag < ellensegNezTavolsag)
            {
                //Debug.Log("ellensegnez");
                //enReneder.material.color = Color.yellow;
                nezjatekos();
              
                
            }
            if (CelpontTavolsag < EllensegtamadasTavlosag )
            {
                //Debug.Log("ellensegtamad");
                tamadas();
                //jatekosstat.EletValtoz(-5);

            }

            if(elet.getJelenelet() < 5 && !adottaranyat)
            {
                jatekosstat.setArany(ertek);
                adottaranyat = true;


            }
        }

        private void tamadas()
        {//játékos felé megy
         //rigid.AddForce(transform.forward * elelnsegMozgasSebesseg);
            if (CelpontTavolsag > 3)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * elelnsegMozgasSebesseg);
                //jatekosstat.EletValtoz(-5f);
            }
            
           
         
            if (tuzel)
            {
               
                StartCoroutine(tam());
               

            }
        }
        IEnumerator tam()
        {
            // Debug.Log("timerenemy");
            tuzel = false;

            yield return new WaitForSeconds(0.5f);
           
            jatekosstat.EletValtoz(tamad);

           

            tuzel = true;
            // print("lőhet");

        }

        private void nezjatekos()
        {
            //forog játékos irányában
            Quaternion forgas = Quaternion.LookRotation(Celpont.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, forgas, Time.deltaTime*2);


        }





           



            }
        }
    
