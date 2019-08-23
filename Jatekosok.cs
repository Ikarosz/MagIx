using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;

namespace MagIx {
    public class Jatekosok : MonoBehaviour
    {
        public string nev;
        public int pont;
        public int elet;
        public GameObject jatekos;
        JatekosStat jatekosstat;

        private IDbCommand OlvasParancs;
        private IDataReader Olvas;

        int id;
        string nevle;
        int pontle;
        int eleterole;

        // Start is called before the first frame update
        private void Start()
        {
            jatekos = GameObject.Find("ThirdPersonController");
            jatekosstat = jatekos.GetComponent<JatekosStat>();

            //Debug.Log(jatekosstat.GetArany() + "arany");
            //Debug.Log(jatekosstat.GetElet() + "elet");
            Debug.Log(jatekosstat.GetId() + "id");
            id = jatekosstat.GetId();
            Adatokle();
            //int id = 0;
            //string nevle = "";
            //int pontle = 0;
            //int eleterole = 0;


        }


        public void Adatokle()
        {

            Debug.Log("kapcsolat0");


            string kapcsolat = "URI=file:" + Application.dataPath + "/gyak/Adatbazis/AB23.s3db";
            //Debug.Log("kapcsolat 1");

            SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
            abKapcs.Open();
            //Debug.Log("kapcsolat2");


            OlvasParancs = abKapcs.CreateCommand();
            // Debug.Log("kapcsolat3");
            OlvasParancs.CommandText = "Select * from Jatekos order by id desc limit 1";
            // Debug.Log("kapcsolat4");
            Olvas = OlvasParancs.ExecuteReader();
            //Debug.Log("kapcsolat5");
            // int tav = 20;
            //Jatekosok jatekos = new Jatekosok();
            while (Olvas.Read())
            {
                id = Olvas.GetInt32(0);
                nevle = Olvas.GetString(1);
                pontle = Olvas.GetInt32(2);
                eleterole = Olvas.GetInt32(3);
            }


            Debug.Log(nevle + "nev   " + pontle + "arany   " + eleterole + "elet   ");
            jatekosstat.SetId(id);
            jatekosstat.SetNev(nevle);
            jatekosstat.SetAranyle(pontle);
            jatekosstat.SetElet(eleterole);
            // jatekosstat.SetNev(nevle);


            //jatekosstat.arany= pontle;
            abKapcs.Close();
            abKapcs = null;

        }
        public void Adatokfel()
        {




            Debug.Log("jatekosadatvfel");

            //Debug.Log("kapcs jó");


            //Debug.Log(nevtext.text + "nevtext");

            string kapcsolat = "URI=file:" + Application.dataPath + "/gyak/Adatbazis/AB23.s3db";


            SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
            abKapcs.Open();



            Debug.Log("jatekosadatvfel1");



            SqliteCommand parancs = abKapcs.CreateCommand();

            Debug.Log("jatekosadatvfel2");
            //+jatekosstat.GetNev();
            //jelenlegi adatok feltöltése
            Debug.Log(jatekosstat.GetArany() + "arany");
            Debug.Log(jatekosstat.GetElet() + "elet");
            Debug.Log(jatekosstat.GetId() + "id");
            Debug.Log("jatekosadatvfel3");


            string lek1 = "UPDATE Jatekos SET Pont = " + jatekosstat.GetArany() + ", Elet = " + jatekosstat.GetElet() + " WHERE id=' " + jatekosstat.GetId() + "'";

            //string lek1 = "UPDATE Jatekos SET Pont = 4, Elet = 4 WHERE Neve='alma'";

            Debug.Log("jatekosadatvfel2 ");
            Debug.Log(lek1);

            parancs.CommandText = lek1;

            parancs.ExecuteNonQuery();


            //Debug.Log("kapcsolat3");

            parancs.Dispose();
            parancs = null;
            abKapcs.Close();
            abKapcs = null;
        }



        //public void betoltjelen(int id){




        //    string kapcsolat = "URI=file:" + Application.dataPath + "/gyak/Adatbazis/AB23.s3db";


        //    SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
        //    abKapcs.Open();





        //    SqliteCommand parancs = abKapcs.CreateCommand();

           


        //    string lek1 = "UPDATE JatekosJelen SET Id = " + id + " WHERE id= (Select id from JatekosJelen order by id desc limit 1)";

        //    //string lek1 = "UPDATE Jatekos SET Pont = 4, Elet = 4 WHERE Neve='alma'";


        //    parancs.CommandText = lek1;

        //    parancs.ExecuteNonQuery();


        //    //Debug.Log("kapcsolat3");

        //    parancs.Dispose();
        //    parancs = null;
        //    abKapcs.Close();
        //    abKapcs = null;


                


        //}
        public void halal()
        {
            string kapcsolat = "URI=file:" + Application.dataPath + "/gyak/Adatbazis/AB23.s3db";


            SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
            abKapcs.Open();







            SqliteCommand parancs = abKapcs.CreateCommand();

            //jelenlegi adatok feltöltése
            string lek1 = "DELETE FROM Jatekos WHERE  Neve= '" + jatekosstat.GetNev();



            Debug.Log(lek1);

            parancs.CommandText = lek1;

            parancs.ExecuteNonQuery();


            //Debug.Log("kapcsolat3");

            parancs.Dispose();
            parancs = null;
            abKapcs.Close();
            abKapcs = null;
        }
        // Update is called once per frame
        void Update()
        {
           
        }
    }
}