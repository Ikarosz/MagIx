using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JatekMenu : MonoBehaviour
{


    public bool Jatékszünet;
    public GameObject szünetmenu;

 
    // Start is called before the first frame update
    void Start()
    {//
        Jatékszünet = false;
        Time.timeScale = 1f;
    }
  public bool getJatekszunet()
    {
        return Jatékszünet;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Debug.Log("esc");
            
            if (Jatékszünet)
            {
               Folytat();
            }else
            {
               
                Szünet();
            }
        }
    }

    public void Szünet()
    {
     
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        szünetmenu.SetActive(true);
        Time.timeScale = 0f;
        Jatékszünet = true;
    }

    public void Folytat()
    {


      
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Jatékszünet = false;
        szünetmenu.SetActive(false);

    }

    public void Menütöltés()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
       
    }


}
