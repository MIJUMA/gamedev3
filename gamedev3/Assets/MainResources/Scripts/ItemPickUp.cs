﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    public void Interact() {

        PickUp();
    }

     void PickUp ()
    {
        Debug.Log("Picking up item." + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);
        

        if (wasPickedUp)
        {
            Destroy(gameObject);
        }

    }
}
