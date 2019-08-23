    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace MagIx
{

    public class Élet : MonoBehaviour
    {
     public GameObject A;

        public Transform Elet;
        public Slider Elettölt;

        public float jelenlegiElet;

        public float teljesElet;

        public float Elety = 2;

        private JatekosStat jatekstat;
        public GameObject jatekos;
        public AIcontroll ai;

        private int arany;
        private void Start()
        {
            arany = 1;
               jatekos = GameObject.Find("ThirdPersonController");
            jatekstat = jatekos.GetComponent<JatekosStat>();
            ai = gameObject.GetComponent<AIcontroll>();

        }
        // Update is called once per frame
        void Update()
        {
            PozicioElet();
        }


        public void EletValtoz(int ertek )
        {
            //Debug.Log("ertekcsokken");
            jelenlegiElet += ertek;
            jelenlegiElet = Mathf.Clamp(jelenlegiElet, 0, teljesElet);

            Elettölt.value = jelenlegiElet / teljesElet;

            if (jelenlegiElet <= 1)
            {
                //Debug.Log("megoliazellenseged");
                jatekstat.setArany(arany);
                Destroy(gameObject);
              
            }

        }
        public float getJelenelet()
        {
            return jelenlegiElet;
        }

        private void PozicioElet()
        {
            Vector3 jelenlegiPoz = transform.position;

            Elet.position = new Vector3(jelenlegiPoz.x, jelenlegiPoz.y + Elety, jelenlegiPoz.z);

            Elet.LookAt(Camera.main.transform);
        }
    }
}