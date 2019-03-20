using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffFlame : MonoBehaviour {

    public Transform flame;

    // Start is called before the first frame update
    void Start()
    {

        flame.GetComponent<ParticleSystem>().enableEmission = true;

    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cup" || other.gameObject.name == "WaterDrop")
        {
            flame.GetComponent<ParticleSystem>().enableEmission = false;

            Debug.Log("Turned off");
        }
    }
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            flame.GetComponent<ParticleSystem>().enableEmission = false;
        }
    }
}
