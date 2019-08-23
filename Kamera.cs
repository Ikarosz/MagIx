using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour {
    private const float Y_MIN_Szög = 0.0f;
    private const float Y_MAX_Szög = 50.0f;

    public float alfa = 0;

    float deltaGlobalszog;

    public Transform Jatekoscelpont;
    public Transform KameraTransform;
    public Transform celpontlock;

    public Quaternion forgas;



    public float tavolsagkarakter = 1.0f;
    private float jelenlegiX = 0.0f;
    private float jelenlegiY = 0.0f;
    private float egererzekenysegX = 4.0f;
    private float egererzekenysegY = 1.0f;


    public Transform Ellenseg;

   

    private void Start()
    {//kamera helyzete
        
        //Debug.Log(Camera.main.fieldOfView);
      

        KameraTransform = transform;
     
        //eger kikapcsolása és lockolása
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }


    private void Update()
    {

        görgetés();

        jelenlegiX += Input.GetAxis("Mouse X");
        jelenlegiY += Input.GetAxis("Mouse Y");
        //mozgatási szög
        jelenlegiY = Mathf.Clamp(jelenlegiY, Y_MIN_Szög, Y_MAX_Szög);

    }

    void görgetés(){
        if (Input.GetAxis("Mouse ScrollWheel") > 0f && tavolsagkarakter > 0.5f)
        {
            tavolsagkarakter -= 0.2f;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && tavolsagkarakter< 3f)
        {
            tavolsagkarakter += 0.2f;
        }
        


    }

    private void LateUpdate()
    {
        Vector3 irany = new Vector3(0, 0, -tavolsagkarakter);
        Quaternion forgas = Quaternion.Euler(jelenlegiY + 7, jelenlegiX, 20 );
  

        KameraTransform.position = Jatekoscelpont.position + forgas * irany;
        KameraTransform.LookAt(Jatekoscelpont.position);


       // lockkamera();



    }


    private void lockkamera(){
        float deltaszog = 0f;



        float Jatekosvektorx = (KameraTransform.position.x - Jatekoscelpont.position.x);
        float Jatekosvektorz = (KameraTransform.position.z - Jatekoscelpont.position.z);
        Vector2 Jatekosvektor = new Vector2(Jatekosvektorx, Jatekosvektorz);


        float Celpontx = (KameraTransform.position.x - celpontlock.position.x);
        float Celpontz = (KameraTransform.position.z - celpontlock.position.z);
        Vector2 Celpont = new Vector2(Celpontx, Celpontz);



        alfa = Vector2.Angle(Jatekosvektor, Celpont);
        deltaszog = alfa-Camera.main.fieldOfView / 2;
       if (deltaszog>0 )
        {

            // forgas = Quaternion.Euler(0, jelenlegiX+ deltaszog, 0);
            deltaGlobalszog = deltaszog;


        }
        else
        {
            deltaGlobalszog = 0;
        }



        //alfa = (Jatekosvektorx * Celpontx + Jatekosvektorz * Celpontz) / (Mathf.Sqrt((Mathf.Pow(Jatekosvektorx, 2) + (Mathf.Pow(Jatekosvektorz, 2)))) + (Mathf.Sqrt((Mathf.Pow(Celpontx, 2) + (Mathf.Pow(Celpontz, 2))))));
        //// double alfa = System.Math.Acos(alfa);
        //double alfadouble = System.Math.Acos(alfa);
        //alfa= (float)alfadouble;
        //Debug.Log(System.Math.PI * alfadouble / 180.0 +"alfa");


    }





  

    
}







