using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


namespace MagIx
{


    public class Follower : MonoBehaviour
    {



   
        public Transform Nezcel;
        public Transform kameraTransform;

        public float mozgasiSeb;
        public GameObject jatekos;
       

     
        private float currentX = 0.0f;
        private float currentY = 0.0f;
        private float sensitivityX = 4.0f;
        private float sensitivityY = 1.0f;

        private bool enter = false;

        public float ido;
        public Text idozito;


       


        private void Start()
        {
            
            //Debug.Log(jatekos);
            StartCoroutine(Timer());
           
         // Nezcel = jatekos.transform;
            //kameraTransform = this.transform;
            idozito = GameObject.Find("KépTölt").GetComponent<Text>();

            ido = 10;


        }
        private void Update()
        {
            CD();



            currentX += Input.GetAxis("Mouse X");
            //  currentY += Input.GetAxis("Mouse Y");
            // currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_Max);




        }

        private void LateUpdate()
        {


        



            Vector3 helyzet = new Vector3(-1, 2, 0);
            // jatekos.transform.position = new Vector3(jatekos.transform.position.x, jatekos.transform.position.y, 1f);



            //this.transform.position = jatekos.transform.position+ helyzet;
            //this.transform.position = jatekos.transform.position+ helyzet;

            //this.transform.position = Vector3.MoveTowards(transform.position, jatekos.transform.position + dir, mozgasiSeb);
            Quaternion forgas = Quaternion.Euler(currentY, currentX, 10);


            this.transform.position = Nezcel.position + forgas * helyzet;
             //this.transform.position = Vector3.MoveTowards(transform.position, camTransform.position, movementSpeed);

            //camTransform.LookAt(lookAt.position);
        }
        IEnumerator Timer()
        {


            yield return new WaitForSeconds(10);
           

          //  print("jó!!");
            gameObject.SetActive(false);

        }



        public void CD()
        {
           
            if (ido < 0) { 
            enter = true;
                idozito.text = " ";
            }
            else
                enter = false;



            if (enter == false)
            {
              //  print("kezdet");
                StartCoroutine(Timer());
                ido -= Time.deltaTime;
                idozito.text = ido.ToString("0");
               
            }
            else if (enter == true)
            {
               
                ido = 10;
            }
        }

    }

}






