using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




namespace MagIx
    {
        public class AIcontroll1 : MonoBehaviour
        {
            
           public float táv;
        public GameObject[] Játékos;






        public GameObject ellenseg;

        public float CelpontTavolsag;
            public float ellensegNezTavolsag;
            public float EllensegtamadasTavlosag;
            public float elelnsegMozgasSebesseg;
        //public float daming;
        public GameObject Celpont;
        Rigidbody rigid;
        Renderer enReneder;
        JatekosStat jatekosstat;


        public Rigidbody lövedék;
        public Transform Lő;
        //public Transform a;
        public float erő = 1000f;
        public float mozgás = 10f;
        public GameObject löv;
        public float tamadasforgas;
        public bool tuzel;
        //public float tamad;
        public int ertek;
        Élet elet;
        // Start is called before the first frame update
        void Start()
            {
            ertek = 5;
            elet = gameObject.GetComponent<Élet>();
            Celpont = GameObject.Find("ThirdPersonController");

            
            enReneder = GetComponent<Renderer>();
            rigid = GetComponent<Rigidbody>();
            tuzel = true;
          // tamad = -0.1f;
            //getcomponentel masik class fuggvenyhivas, mivel a letezo script kell.
           // jatekosstat = Celpont.GetComponent<JatekosStat>();


        }
        public void kiir()
        {
            Debug.Log("AI.kiiir");
        }
    void Update()
        {
            
            // tamadasforgas = UnityEngine.Random.Range(-5, 0);

            rigid.velocity = new Vector3(0, -30, 0);
//
           // Debug.Log("ellenseg");
            CelpontTavolsag = Vector3.Distance(Celpont.transform.position, ellenseg.transform.position);

            if (CelpontTavolsag < ellensegNezTavolsag)
            {
              //  Debug.Log("ellensegnez");
                //enReneder.material.color = Color.yellow;
                nezjatekos();
              
                
            }
            if (CelpontTavolsag < EllensegtamadasTavlosag)
            {
               //Debug.Log("ellensegtamad");
                tamadas();
              
            }
            if (elet.getJelenelet() <= 1)
            {
                jatekosstat.setArany(ertek);


            }
        }

        private void tamadas()
        {//játékos felé megy
         //  rigid.AddForce(transform.forward * elelnsegMozgasSebesseg);
         // transform.Translate(Vector3.forward  * Time.deltaTime * elelnsegMozgasSebesseg);

          
            if (tuzel) {
               // Debug.Log("enemy tuzel");
                StartCoroutine(golyotime());
                //    Rigidbody Lőv = Instantiate(lövedék, Lő.position, lövedék.rotation) as Rigidbody;


                //Lőv.AddForce(Lő.forward * erő);

            }
        }

        IEnumerator golyotime()
        {
           // Debug.Log("timerenemy");
            tuzel = false;

            yield return new WaitForSeconds(0.5f);
            Rigidbody Lőv = Instantiate(lövedék, Lő.position, lövedék.rotation) as Rigidbody;


            Lőv.AddForce(Lő.forward * erő);

            tuzel = true;
           // print("lőhet");

        }

        private void nezjatekos()
        {
            //forog játékos irányában
            Quaternion forgas = Quaternion.LookRotation(Celpont.transform.position - transform.position);
          
            transform.rotation = Quaternion.Slerp(transform.rotation, forgas, Time.deltaTime);


        }





           



            }
        }
    
