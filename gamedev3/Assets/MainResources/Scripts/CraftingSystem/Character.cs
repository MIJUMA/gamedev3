using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    
    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatsPanel statsPanel;

    
    public List<CraftingRecipe> GetStatsRecipes()
    {
        return statsPanel.GetCraftedRecipes();
    }

    private void Awake()
    {
        //statsPanel.SetCharacterStats(CandleCup, ChildCup, ChildCandle);
        //statsPanel.UpdateCharacterStatValues();

        inventory.OnItemRightClickedEvent += EquipFromInventory;
        equipmentPanel.OnItemRightClickedEvent += UnequipFromEquipPanel;
    }

    private void Update()
    {
        if (equipmentPanel.GetCraftedRecipes().Count != 0)
        {
            statsPanel.SetCharacterRecipes(equipmentPanel.GetCraftedRecipes());
            //statsPanel.UpdateCharacterStatValues();
        }
    }

    
    private void EquipFromInventory(Item item)
    {
        if (item is EquippableItem)
        {
            Equip((EquippableItem)item);
            
        }
    }

    public void CraftItem()
    {
        List<Item> items = equipmentPanel.CraftItem();
        foreach (Item i in items)
        {
            inventory.AddItem(i);
        }
    }

    private void UnequipFromEquipPanel(Item item)
    {
        if (item is EquippableItem)
        {
            Unequip((EquippableItem)item);
        }
    }


    public void Equip(EquippableItem item)
    {
        if (inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (equipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    inventory.AddItem(previousItem);
                }
            }
            else
            {
                inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (!inventory.IsFull() && equipmentPanel.RemoveItem(item))
        {
            inventory.AddItem(item);
        }
    }


    public void ClosePanel()
    {

    }


    public List<Item> GetInventoryItems()
    {
        return inventory.GetItems();
    }



}
