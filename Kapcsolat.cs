using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;



namespace MagIx { 

public class Kapcsolat : MonoBehaviour
{

        //Menu menu;
        public Button ujJatekGomb;
        public Button BetoltesGomb;
        public Text nevtext;
        //lekerdezes
        private IDbCommand OlvasParancs;
        private IDataReader Olvas;
        //gombok lekérdezése.
        public GameObject GombPrefab;
        public GameObject UjGombHely;
        public GameObject MentesText;
        
        void Start() 
            

    {

          

            ABLetre();

        }
        public void Betoltjelen(int id)
        {




            string kapcsolat = "URI=file:" + Application.dataPath + "/gyak/Adatbazis/AB1.s3db";


            SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
            abKapcs.Open();





            SqliteCommand parancs = abKapcs.CreateCommand();




            string lek1 = "UPDATE JatekosJelen SET Id = " + id + " WHERE id= (Select id from JatekosJelen order by id desc limit 1)";
            Debug.Log(lek1);
        

            parancs.CommandText = lek1;

            parancs.ExecuteNonQuery();


            //Debug.Log("kapcsolat3");

            parancs.Dispose();
            parancs = null;
            abKapcs.Close();
            abKapcs = null;





        }
        void Update()
    {
         

            ujJatekGomb.onClick.AddListener(Kapcs);
            
            ujJatekGomb.onClick.AddListener(null);
            BetoltesGomb.onClick.AddListener(Lekerd);
            BetoltesGomb.onClick.AddListener(null);


        }


         void Kapcs()
        {


    



            Debug.Log("kapcs jó");
           
          
            Debug.Log(nevtext.text+"nevtext");

            string kapcsolat = "URI=file:" + Application.dataPath + "AB1.s3db";
            

            SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
            abKapcs.Open();
           

         
          



            SqliteCommand parancs = abKapcs.CreateCommand();


            // string lek2 = "";

            //OlvasParancs = abKapcs.CreateCommand();
            //Debug.Log("lekerd");
            //OlvasParancs.CommandText = " (Select * from JelenJatekos)";
            //Debug.Log(OlvasParancs.CommandText);


            //Olvas = OlvasParancs.ExecuteReader();
            ////while (Olvas.Read())
            ////{
            ////    Debug.Log("");
            ////}
            //Debug.Log(Olvas.GetString(1)+"lekerdnev");
            
            //Debug.Log(Olvas + "debug");
            //Debug.Log(Olvas.GetInt32(0) + "id");
            //Debug.Log(Olvas.GetString(1) + "nev");

            //while (Olvas.Read())
            //{
            //    Debug.Log(Olvas.GetInt32(0) + "id");

            //    if (Olvas.GetInt32(0) == null)
            //    {


                    //  string lek2 = "IF EXISTS INSERT JelenJatekos INTO JelenJatekos(id,Neve) VALUES(1,'" + nevtext.text + "')";
                    //    }
                    //}

                    string lek1 = "INSERT INTO Jatekos(Neve,Pont,Elet) VALUES('"+ nevtext.text + "',0,50)";

            //string lek2 = " BEGIN IF NOT EXISTS(SELECT * FROM JelenJatekos) BEGIN INSERT INTO JelenJatekos( Neve) VALUES( '" + nevtext.text + "') END END ";


            Debug.Log(lek1);

         
            parancs.CommandText = lek1;
            parancs.ExecuteNonQuery();
            //parancs.CommandText = lek2;

            //parancs.ExecuteNonQuery();


            //Debug.Log("kapcsolat3");

            parancs.Dispose();
            parancs = null;
            abKapcs.Close();
            abKapcs = null;
        }
      
        void ABLetre()
        {

            //letrehoz sqlfilet ha nem létezik, ha igen akkor abba lép bele
            string kapcsolat = "URI=file:" + Application.dataPath + "AB1.s3db";
            //Debug.Log("kapcsolat 1");

            SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
            abKapcs.Open();

           



            //Debug.Log("kapcsolat2");




            SqliteCommand parancs = abKapcs.CreateCommand();
            string sql = "CREATE TABLE IF NOT EXISTS Jatekos (id INTEGER PRIMARY KEY AUTOINCREMENT, Neve VARCHAR(20), Pont INTEGER,Elet INTEGER)";
       string sql2 = "CREATE TABLE IF NOT EXISTS JelenJatekos (id INTEGER PRIMARY KEY AUTOINCREMENT, Neve VARCHAR(20), palya INTEGER)";
              
           
           
            parancs.CommandText = sql;
            parancs.ExecuteNonQuery();
            parancs.CommandText = sql2;

            parancs.ExecuteNonQuery();


            parancs.Dispose();
            parancs = null;
            abKapcs.Close();
            abKapcs = null;

        }

        void Lekerd()
        {

            Debug.Log("kapcs jó");




            string kapcsolat = "URI=file:" + Application.dataPath + "AB1.s3db";
            //Debug.Log("kapcsolat 1");

            SqliteConnection abKapcs = new SqliteConnection(kapcsolat);
            abKapcs.Open();
            Debug.Log("kapcsolat2");


            OlvasParancs = abKapcs.CreateCommand();
            OlvasParancs.CommandText="Select * from Jatekos";
            Olvas = OlvasParancs.ExecuteReader();
            int tav = 50;
            //Jatekosok jatekos = new Jatekosok();
            while (Olvas.Read())
            {
                int id = Olvas.GetInt32(0);
                string nev = Olvas.GetString(1);
                int pont = Olvas.GetInt32(2);
                int eletero = Olvas.GetInt32(3);
                //Gombok létrehozása
                var ujtext = Instantiate(MentesText, new Vector3(MentesText.transform.position.x, MentesText.transform.position.y - tav, 0), Quaternion.identity);
                ujtext.GetComponent<Text>().text = " Pont:" + pont + " Elet:" + eletero;
                ujtext.transform.parent = UjGombHely.transform;
                var ujgomb = Instantiate(GombPrefab, new Vector3(GombPrefab.transform.position.x, GombPrefab.transform.position.y - tav, 0), Quaternion.identity);
                ujgomb.transform.localScale += new Vector3(0.4444445F, 0.4002882f, 0);
                ujgomb.transform.parent = UjGombHely.transform;
                ujgomb.GetComponentInChildren<Text>().text = nev+id;
               
                ujgomb.transform.GetChild(1).GetComponent<Text>().text = id+"";
                //Debug.Log(nev);
                //GameObject gomb = (GameObject)Instantiate(GombPrefab, new Vector3(GombPrefab.transform.position.x , 0, GombPrefab.transform.position.y + tav), Quaternion.identity);

                Debug.Log(id + "/ " + nev + "/ " + pont + "/ " + eletero);
                tav += 50;
            }

           
            abKapcs.Close();
            abKapcs = null;
        }
    }
}