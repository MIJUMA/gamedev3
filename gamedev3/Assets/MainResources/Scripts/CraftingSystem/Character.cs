using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public CharacterStat CandleCup;
    public CharacterStat ChildCup;
    public CharacterStat ChildCandle;

    [SerializeField] Inventory inventory;
    [SerializeField] EquipmentPanel equipmentPanel;
    [SerializeField] StatsPanel statsPanel;

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


}
