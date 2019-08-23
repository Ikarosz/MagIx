using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1 : MonoBehaviour
{


    //Variables
    public float momeventSpeed;
    public GameObject playerMovePoint;
    private Transform pmr;
    private bool pmrSpawned;
    private bool moving;

    public float movementSpeed;
    public GameObject player2;
    public float distance = 1f;

    Animation anim;



    private void Start()


    {


        anim = GetComponent<Animation>();
    }

    //Functions



    private void Update() 

    {
      
        anim.CrossFade("walk");
       
        Vector3 dir = new Vector3(0, 0, -distance);

        this.transform.position = Vector3.MoveTowards(transform.position, player2.transform.position + dir, movementSpeed);






        //Player movement
        Plane playerPlane = new Plane(Vector3.up, transform.position);
      Ray ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitDistance = 0.0f;

        if (playerPlane.Raycast(ray, out hitDistance))
        {
            Vector3 targetPoint = ray.GetPoint(hitDistance);
            if (Input.GetMouseButtonDown(0))
            {
                moving = true;
                if (pmrSpawned)
                {
                    pmr = null;
                    pmr = Instantiate(playerMovePoint.transform, transform.position, Quaternion.identity);


                }
                pmr = Instantiate(playerMovePoint.transform, transform.position, Quaternion.identity);
            }
            else
            {
                pmr = Instantiate(playerMovePoint.transform, transform.position, Quaternion.identity);
            }

        }
        if (pmr)
            pmrSpawned = true;
        else
        {
            pmrSpawned = false;
        }
        if (moving)
        {
            Move();
                }

    }
    public void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, pmr.transform.position, momeventSpeed);
        this.transform.LookAt(pmr.transform);
    }
}
