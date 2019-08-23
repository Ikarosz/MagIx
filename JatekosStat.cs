using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MagIx
{
    public class JatekosStat : MonoBehaviour
    {
        private int Id;
        private int arany;
        public Text aranytext;
        public Slider eletcsik;

        private float jelenlegiElet;

        private float teljesElet;

        public GameObject Jatekos;

        public GameObject Jatekoshud;

        public GameObject szünetmenu;


        private string nev;

        Jatekosok jatekosadat;
        
        public GameObject main;

        // Start is called before the first frame update
    
        void Start()
        {

            main = GameObject.Find("Main");
            Debug.Log("jatekos adatbazis0");
            jatekosadat = main.GetComponent<Jatekosok>();
            Debug.Log("jatekos adatbazis");

          //  jatekosadat.Adatokle();
          // nev= jatekosadat.nev ;
          //arany=  jatekosadat.pont ;

          //  jelenlegiElet = (float)jatekosadat.elet;


           

            //beertek = 0f;
            //eletcsik.value = 0.5f;
            // teljesElet = 50f;
            jelenlegiElet = teljesElet;


            // Debug.Log(eletcsik.value+"ertekslider");
            //arany = 0;
            //teljesElet = 50;
            //jelenlegiElet=0;
            //Elettölt = Jatekoshud.transform.Find("Elet").GetComponent<Slider>;
            //eletcsik = GameObject.FindGameObjectWithTag("eletCsuszka").GetComponent<Slider>();
            // Debug.Log(eletcsik );


            this.eletcsik.value = this.jelenlegiElet;
        }
      
        public void kiir()
        {
            Debug.Log("jatekstatkiir");
        }
        //public float getElet()
        //{
            
        //    return jelenlegiElet;
        //}
        //public float setEletertek(float ertekvalt)
        //{
            
        //    return ertek+ertekvalt;
        //}
            public void EletValtoz(float ertek )
        {

          //Debug.Log(ertek+" ertek valtozik");

          //  Debug.Log(eletcsik + "slim");
          //  Debug.Log("teljes: "+teljesElet + "slim");
          //  Debug.Log("jelen:"+jelenlegiElet + "slim");
           // Debug.Log(eletcsik + "slim");

            // Debug.Log(jelenlegiElet + "jelen valtozik");
            // Debug.Log(teljesElet + "teljes valtozik");
            this.jelenlegiElet = this.jelenlegiElet + ertek;
            //Debug.Log(ertek +"jelen:"+ jelenlegiElet+ " 1ertek valtozik");

            //vissza adja az értéket ha nem kisebb mint 0 vagy nagyobb mint az eredeti
            this.jelenlegiElet = Mathf.Clamp(this.jelenlegiElet, 0, this.teljesElet);
           // Debug.Log(ertek + "jelen "+ jelenlegiElet + "tel"+ teljesElet+" 2ertek valtozik");

           // Debug.Log(eletcsik + " csuszka");
           // Debug.Log(this.jelenlegiElet / this.teljesElet+"ertek");
            this.eletcsik.value = this.jelenlegiElet / this.teljesElet;
           // Debug.Log(ertek + " 3ertek valtozik");


            if (jelenlegiElet <= 0)
            {

              
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                //ha meghal a játékos akkor a szunetmenu 2. gyerekét aktiválja vége és állítsa meg az időt
                szünetmenu.transform.GetChild(1).gameObject.SetActive(true);
                Debug.Log(szünetmenu.transform.GetChild(0)+"jatekvege");
                Time.timeScale = 0f;
                gameObject.SetActive(false);
              
            }


           // Debug.Log(jelenlegiElet+"jelen"+ teljesElet+"teljes");
        }

            // Update is called once per frame
            void Update()
        {
            Debug.Log(Id);
            Debug.Log(nev + "  elsojatekoos " + arany + "  elso " + jelenlegiElet);
            //EletValtoz(-5);
            aranytext.text = "arany:  "+arany;
        }

        public void setArany(int ertek)
        {
            Debug.Log(ertek+"bejovo aranys");
          arany=  (arany + ertek);
        }

        public int GetArany()
        {
            Debug.Log("Getarany");
            return arany;
        }

        public int GetElet()
        {
            Debug.Log("Getelet");

            return (int)jelenlegiElet;
        }

        public void SetAranyle( int arany)
        {

            this.arany = arany;
        }

        public void SetElet(int elet)
        {

           this.jelenlegiElet = (float)elet;
        }
        public string GetNev()
        {
            Debug.Log("Getnev");

            return nev;
        }
        public void SetNev(string nev)
        {

            this.nev = nev;
        }
        public void SetId(int id)
        {

            this.Id = id;
        }
        public int GetId()
        {
            Debug.Log("GetId");
            return Id;
        }
    }
}