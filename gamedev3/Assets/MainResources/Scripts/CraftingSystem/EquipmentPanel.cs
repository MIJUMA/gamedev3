using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
    [SerializeField] Transform equipmentSlotsParent;
    [SerializeField] EquipmentSlot[] equipmentSlots;
    [SerializeField] CraftingRecipe[] craftingRecipes;
    private List<CraftingRecipe> craftedRecipes = new List<CraftingRecipe>();

    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            equipmentSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }
    }

    private void OnValidate()
    {
        equipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
    }


    public bool AddItem(EquippableItem item, out EquippableItem previousItem)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].EquipmentType == item.EquipmentType)
            {
                if (equipmentSlots[i].Item != null)
                {
                    continue;
                }
                previousItem = (EquippableItem)equipmentSlots[i].Item;
                equipmentSlots[i].Item = item;
                return true;
            }
            
        }
        previousItem = null;
        return false;
    }

    public bool IsSomeSlotEmpty(EquipmentType type)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == null)
            {
                return true;
            }

        }
        return false;
    }

    public bool RemoveItem(EquippableItem item)
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == item)
            {
                equipmentSlots[i].Item = null;
                return true;
            }

        }
        return false;
    }

    public void RemoveItems()
    {
        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item is EquippableItem)
            {
                RemoveItem((EquippableItem)equipmentSlots[i].Item);
            }
            
        }
    }


    public void CraftItem()
    {
        if (CanCraft())
        {
            foreach (CraftingRecipe recipe in craftingRecipes)
            {
                if (isRecipeValid(recipe))
                {
                    recipe.resultDialogue.TriggerDialogue();
                    RemoveItems();
                    craftedRecipes.Add(recipe);
                    break;
                }
            }
        }
        
        
    }

    public List<CraftingRecipe> GetCraftedRecipes()
    {
        //Copy maybe?
        return this.craftedRecipes;
    }

    private bool isRecipeValid(CraftingRecipe recipe)
    {
        foreach (ItemAmount itemAmount in recipe.Materials)
        {
            bool found = false;
            foreach (EquipmentSlot slot in equipmentSlots)
            {
                if (itemAmount.Item.ItemName == slot.Item.ItemName)
                {
                    found = true;
                }
            }
            if (!found)
            {
                return false;
            }
        }
        

        return true;
    }

    private bool CanCraft()
    {

        for (int i = 0; i < equipmentSlots.Length; i++)
        {
            if (equipmentSlots[i].Item == null)
            {
                return false;
            }

        }
        return true;
    }
}
