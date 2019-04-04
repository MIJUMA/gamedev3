using UnityEngine;

public class ItemPickUp : Interactable
{

    public Item item;   // Item to put in the inventory if picked up

    // When the player interacts with the item
    public override void Interact()
    {
       Debug.Log("Pick");
       base.Interact();

       PickUp();
    }

    // Pick up the item
    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool wasPickedUp = Inventory.instance.Add(item);   // Add to inventory

        if (wasPickedUp)
        {
            Destroy(gameObject);    // Destroy item from scene
        }
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : Interactable
{
    public Item item;

    public override void Interact()
    {
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
}*/
