using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFire : MonoBehaviour
{

    public Transform flame;

    // Use this for initialization
    void Start()
    {
        flame.GetComponent<ParticleSystem>().enableEmission = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Candle_Small")
        {
            flame.GetComponent<ParticleSystem>().enableEmission = true;
            Debug.Log("Hit");
        }

    }
}