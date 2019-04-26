using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject inventorySlotsContainer;
    public Camera fpsCam;
    public float range = 1000f;
    public GameObject InventoryItemsContainer;
    public GameObject inventorySlots;

    private bool inventoryActive;
    private Button[] slots;

    // Start is called before the first frame update
    void Start()
    {
        inventoryActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryActive)
            {
                inventorySlotsContainer.gameObject.SetActive(false);
            }
            else
            {
                inventorySlotsContainer.gameObject.SetActive(true);
            }

            inventoryActive = !inventoryActive;
        }

        if (Input.GetMouseButtonDown(0))
        {
            PickupItem();
        }
    }
    public void PickupItem()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            if (hit.transform.CompareTag("Items"))
            {
                hit.transform.SetParent(InventoryItemsContainer.transform);
                AddToInventory(hit.transform);
                Debug.Log("Hitting:" + hit.transform.name);
            }
        }
    }
    public void AddToInventory(Transform item)
    {
        Debug.Log("Adding to Inventory...");
        slots = inventorySlots.GetComponentsInChildren<Button>();

        for (int i = 0; i < slots.Length; i++)
        {
            RawImage rImg = slots[i].GetComponentInChildren<RawImage>();
            if (rImg.texture == null)
            {
                rImg.texture = item.GetComponent<RawImage>().texture;
                return;
            }
        }
    }
}
