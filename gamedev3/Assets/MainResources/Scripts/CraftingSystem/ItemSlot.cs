using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] Image image;

    public event Action<Item> OnRightClickEvent;

    private Item _item;
    public Item Item
    {
        get { return _item; }
        set
        {
            _item = value;
            if (_item == null)
            {
                image.enabled = false;
            }
            else
            {
                image.sprite = _item.icon;
                image.enabled = true;
            }
        }
    }


    protected virtual void OnValidate()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (eventData != null && (eventData.button == PointerEventData.InputButton.Left || (eventData.pointerCurrentRaycast.gameObject.name == "Item Slot" || eventData.pointerCurrentRaycast.gameObject.name == "CraftableResource Slot")))
        {
            Debug.Log(eventData.pointerCurrentRaycast.gameObject);
            if (Item != null && OnRightClickEvent != null)
            {
                OnRightClickEvent(Item);
            }
        }
    }
}
