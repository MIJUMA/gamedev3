using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemChest : MonoBehaviour
{
    [SerializeField] Item item;
    [SerializeField] GameObject itemObject;
    [SerializeField] int amount = 1;
    [SerializeField] Inventory inventory;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Color emptyColor;
    [SerializeField] KeyCode itemPickupKeyCode = KeyCode.E;

    private bool alreadyPicked = false;

    private bool isInRange = true;
    private bool isEmpty;

    private void OnValidate()
    {
        if (inventory == null)
            inventory = FindObjectOfType<Inventory>();

        if (spriteRenderer == null)
            spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        spriteRenderer.sprite = item.icon;
        spriteRenderer.enabled = false;
    }

    private void Update()
    {
       
        if (!isEmpty && (
             Input.GetKeyDown(itemPickupKeyCode)))
        {
            Item itemCopy = item.GetCopy();
            if (inventory.AddItem(itemCopy))
            {
                amount--;
                if (amount == 0)
                {
                    isEmpty = true;
                    spriteRenderer.color = emptyColor;
                    itemObject.SetActive(false);
                }
            }
            else
            {
                itemCopy.Destroy();
            }
        }
  
    }

   

    private bool IsTapping()
    {
        for(int i = 0; i < Input.touches.Length; i++) {
            if (Input.touches[i].phase == TouchPhase.Began)
            {
                return true;
            }
        }
        return false;
    }

    public void pickUp()
    {
        if (alreadyPicked) { return; }

        alreadyPicked = true;
        Item itemCopy = item.GetCopy();
        if (inventory.AddItem(itemCopy))
        {
            amount--;
            if (amount == 0)
            {
                isEmpty = true;
                spriteRenderer.color = emptyColor;
                itemObject.SetActive(false);
            }
        }
        else
        {
            itemCopy.Destroy();
        }
    }
}