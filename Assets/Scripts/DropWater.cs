using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;

public class DropWater : MonoBehaviour
{


    private MeshRenderer mr;

    public GameObject liquid;

    public float selfRotX;
    public float pourRot;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        liquid = GameObject.FindGameObjectWithTag("Liquid");
    }

    void Update()
    {

        selfRotX = transform.rotation.eulerAngles.x;
        if ((selfRotX > pourRot) && (selfRotX < (360 - pourRot)) && mr.isVisible)
        {
            SpawnLiquid(liquid, transform.position, transform.rotation);
        }

    }

    void SpawnLiquid(GameObject go, Vector3 pos, Quaternion rot)
    {
        GameObject liquidInstance = Instantiate(go, pos, rot);
        Destroy(liquidInstance, 2f);
    }
}
