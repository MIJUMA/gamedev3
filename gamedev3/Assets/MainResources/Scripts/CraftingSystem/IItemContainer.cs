using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemContainer 
{
    bool ContainsItems(Item item);
    int ItemCount(Item item);
    bool RemoveItem(Item item);
    bool AddItem(Item item);
    bool IsFull();
}
