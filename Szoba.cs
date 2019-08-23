using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MagIx
{
    public class Szoba : MonoBehaviour
    {
        // public GameObject szoba;
      public Transform szobahely;
        


        public GameObject padlo;
        public GameObject fal1;
        public GameObject fal2;
        public GameObject fal3;
        public GameObject fal4;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetButtonUp("E"))
            {
                
              //  Instantiate(szoba, szobahely.position, szoba.rotation)
               // Spawn(szobahely);
            }
        }
       

       
          // An array of the spawn points this enemy can spawn from.


        //void Start()
        //{
        //    // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
        //   // InvokeRepeating("Spawn", spawnTime, spawnTime);
        //}

            public void töltelék(GameObject ellenseg, GameObject pont, Transform szobahely)
        {
            var a = Random.Range(0, 10f);

            for (int i = 0; i < a; i++)
            {


                Vector3 position = new Vector3(Random.Range(szobahely.position.x-5, szobahely.position.x + 5), (szobahely.position.y - (0.8f)), Random.Range(szobahely.position.z - 10f, szobahely.position.z));
                Instantiate(ellenseg, position, Quaternion.identity);


                Vector3 position2 = new Vector3(Random.Range(szobahely.position.x - 5f, szobahely.position.x + 5f), (szobahely.position.y + 1), Random.Range(szobahely.position.z - 10f, szobahely.position.z ));
                Instantiate(pont, position2, Quaternion.identity);
            }
        }
        public void szobaletrehoz(
        GameObject padlo,
         GameObject fal1,
         GameObject fal2,
         GameObject fal3,
      
         Transform szobahely)
        {





       
        Vector3 helyzet = new Vector3(szobahely.position.x, szobahely.position.y-(0.8f)  , szobahely.position.z-5);
            Instantiate(padlo, helyzet, szobahely.rotation);

            Vector3 helyzet2 = new Vector3(szobahely.position.x, szobahely.position.y, szobahely.position.z - 10);
            Instantiate(fal1, helyzet2, szobahely.rotation);

            Vector3 helyzet3 = new Vector3(szobahely.position.x + 5, szobahely.position.y, szobahely.position.z - 5);

          

            Quaternion helyzet3r = Quaternion.Euler(szobahely.rotation.x, szobahely.rotation.y + 90, szobahely.rotation.z);

            Instantiate(fal2, helyzet3, helyzet3r);

            Quaternion helyzet4r = Quaternion.Euler(szobahely.rotation.x, szobahely.rotation.y + 90, szobahely.rotation.z);

            Vector3 helyzet4 = new Vector3(szobahely.position.x - 5, szobahely.position.y, szobahely.position.z - 5);
            Instantiate(fal3, helyzet4, helyzet4r);

     


        }
    }



}





