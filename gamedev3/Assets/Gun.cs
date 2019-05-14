using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Camera fpsCam;
    public Camera arFpsCam;

    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.E;
    public float range = 100f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Shoot();
        }
        else if (Input.GetKeyDown(itemPickupKeyCode))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        /**
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            hit.transform.GetComponent<ItemChest>().pickUp();
       
        }
        **/
        //focusObj = null;
        if ((Input.GetTouch(0).phase == TouchPhase.Stationary) || (Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(0).deltaPosition.magnitude < 1.2f))
        {
            Ray ray = arFpsCam.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Application.Quit();
            }
        }
    }
}
