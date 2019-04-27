using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public RawImage img;
    public GameObject itemsContainer;
    public GameObject inventoryItemsContainer;

    public void DropItem()
    {
        print("Clicked and dropping an item ... ");

        string name = img.texture.name;
        Transform itemTransform = inventoryItemsContainer.transform.Find(name);

        if (itemTransform)
        {
            print("Dropped");
            Transform playerTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
            //itemTransform.SetPositionAndRotation(playerTransform.position, playerTransform.rotation);
            itemTransform.SetPositionAndRotation(itemTransform.position, itemTransform.rotation);
            itemTransform.SetParent(itemsContainer.transform);
            img.texture = null;
        }
    }

}