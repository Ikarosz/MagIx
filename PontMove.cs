using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PontMove : MonoBehaviour {
    public 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.right * Time.deltaTime*10);

       //    transform.Rotate(Vector3.up * Time.deltaTime, Space.World*forgseb);

    }
}
