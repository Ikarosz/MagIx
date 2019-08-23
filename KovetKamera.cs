using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KovetKamera : MonoBehaviour
{
  

    public float CameraMoveSpeed = 120.0f;
    public GameObject CameraFollowObj;
    Vector3 FollowPOS;
    public float szög = 80.0f;
    public float inputSensitivity = 150.0f;
    public GameObject CameraObj;
    public GameObject PlayerObj;
    public float camDistanceXToPlayer;
    public float camDistanceYToPlayer;
    public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float smoothX;
    public float smoothY;
    private float forgy = 0.0f;
    private float forgx = 0.0f;



    // Use this for initialization
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        forgy = rot.y;
        forgx = rot.x;
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        //We setup the rotation of the sticks here
       
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
    

        forgy += mouseX * inputSensitivity * Time.deltaTime;
        forgx += mouseY * inputSensitivity * Time.deltaTime;
        //mozgássi magasság
        forgx = Mathf.Clamp(forgx, -szög, szög);

        Quaternion localRotation = Quaternion.Euler(forgx, forgy, 0.0f);
        transform.rotation = localRotation;

        //CameraUpdater();

    }

    void LateUpdate()
    {
     CameraUpdater();
    }

    void CameraUpdater()
    {
     
        // követendő objektum
        Transform target = CameraFollowObj.transform;

        //követendő objektum felé halad
        float step = CameraMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
