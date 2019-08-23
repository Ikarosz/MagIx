using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

	//Variables
	public float enemyHealth;
        private float health;

    private GameObject player1;

    private bool triggeringPlayer;
    public bool aggro;

    public float attackTimer;
    private float _attackTimer;
    public float movementSpeed;



    // Update is called once per frame
    private void Start()
    
        
        {
       
        player1 = GameObject.FindWithTag("Player1");

        }
    
    void Update () {
        this.transform.position = Vector3.MoveTowards(transform.position, player1.transform.position, movementSpeed);

      

        if (aggro)
        {
            FollowPlayer();
        }
        if(triggeringPlayer)
        {
            FollowPlayer();
        }
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1") ;
        { 
            triggeringPlayer = true; 
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player1") ;
        {
            triggeringPlayer = false;
        }
    }

  //  public void Attack()
  //  {

   // }

    public void FollowPlayer()
    {
        this.transform.position = Vector3.MoveTowards(transform.position, player1.transform.position, movementSpeed);
    }



}
