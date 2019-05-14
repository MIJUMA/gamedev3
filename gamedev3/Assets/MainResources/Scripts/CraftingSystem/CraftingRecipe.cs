using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct ItemAmount
{
    public Item Item;
    public int Amount;
}

[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public Item resultProduct;
    public string progressActionName = "Crafted";

    public bool CanCraft(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in Materials)
        {
            if (itemContainer.ItemCount(itemAmount.Item) < itemAmount.Amount)
            {
                return false;
            }
        }
        return true;
    }

    public void Craft(IItemContainer itemContainer)
    {
        if (CanCraft(itemContainer))
        {
            //resultDialogue.TriggerDialogue();
        }
    }
}
