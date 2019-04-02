using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class CubeBehaviour : MonoBehaviour {

    public Rigidbody diceRigidBody;

    
    // Use this for initialization
    void Start () {
        Debug.Log("Here");
		
	}
	
	// Update is called once per frame
	void Update () {
	
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            System.Random randomGen = new System.Random();
            diceRigidBody.AddForce(new Vector3(0f, ((float)randomGen.Next(200, 300)), 0f));
            diceRigidBody.AddTorque(new Vector3(((float) randomGen.Next(0, 500)), ((float)randomGen.Next(0, 500)), ((float)randomGen.Next(0, 500))));
        }
	}
}
