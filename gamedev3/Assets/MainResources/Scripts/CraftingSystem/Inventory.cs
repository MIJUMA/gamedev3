using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IItemContainer
{
    [SerializeField] List<Item> items;
    [SerializeField] Transform itemsParent;
    [SerializeField] ItemSlot[] itemSlots;

    public event Action<Item> OnItemRightClickedEvent;

    private void Start()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            
            itemSlots[i].OnRightClickEvent += OnItemRightClickedEvent;
        }   
    }

    private void OnValidate()
    {
        if (itemsParent != null)
        {
            itemSlots = itemsParent.GetComponentsInChildren<ItemSlot>();
        }

        RefreshUI();

    }

    private void RefreshUI()
    {
        int i = 0;
        for (;i < items.Count && i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = items[i];
        }

        for (; i < itemSlots.Length; i++)
        {
            itemSlots[i].Item = null;
        }
    }

    public bool AddItem(Item item)
    {
        if (IsFull())
            return false;

        items.Add(item);
        RefreshUI();
        return true;
    }

    public bool RemoveItem(Item item)
    {
        if (items.Remove(item))
        {
            RefreshUI();
            return true;
        }

        return false;
    }

    public bool IsFull()
    {
        return items.Count >= itemSlots.Length;
    }

    public bool ContainsItems(Item item)
    {
        int i = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            return true;
        }

        return false;
    }

    public int ItemCount(Item item)
    {
        int i = 0;
        int count = 0;
        for (; i < items.Count && i < itemSlots.Length; i++)
        {
            count++;
        }

        return count;
    }
}
