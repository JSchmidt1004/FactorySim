using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class InventoryMenu : MonoBehaviour
{
    public static MouseItem mouseItem = new MouseItem();

    public InventoryObject linkedInventory;

    public GameObject inventorySlotUI;
    public GameObject inventoryPanel;

    public List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    #region UnityDefaults

    void OnEnable()
    {
        UpdateSlots();
    }

    #endregion

    #region SlotManagement

    public void CreateSlots()
    {
        if (inventoryPanel != null && inventorySlotUI != null)
        {
            for(int i = 0; i < linkedInventory.slotCount; i++)
            {
                GameObject slotUI = Instantiate(inventorySlotUI, inventoryPanel.transform);
                InventorySlotUI slot = slotUI.GetComponent<InventorySlotUI>();

                AddEvent(slot, EventTriggerType.PointerEnter, delegate { OnEnter(slot); });
                AddEvent(slot, EventTriggerType.PointerExit, delegate { OnExit(slot); });
                AddEvent(slot, EventTriggerType.BeginDrag, delegate { OnDragStart(slot); });
                AddEvent(slot, EventTriggerType.EndDrag, delegate { OnDragEnd(slot); });
                AddEvent(slot, EventTriggerType.Drag, delegate { OnDrag(slot); });

                slotUIs.Add(slot);
            }
        }
    }

    public void ClearSlots()
    {
        slotUIs.Clear();
    }

    public void UpdateSlots()
    {
        for (int i = 0; i < linkedInventory.slotCount; i++)
        {
            InventorySlot itemSlot = linkedInventory.Container[i];

            if (itemSlot.item != null)
            {
                slotUIs[i].ActivateIconAndCount(itemSlot.item.icon, itemSlot.amount);
            }
            else
            {
                slotUIs[i].DeactivateIconAndCount();
            }

            slotUIs[i].representedItem = itemSlot;
        }
    }

    #endregion

    #region SubscriptionManagement

    public void SubscribeToInventory()
    {
        if (linkedInventory != null)
        {
            linkedInventory.onItemChangedCallback += UpdateSlots;
        }
    }

    public void UnsubscribeFromInventory()
    {
        if (linkedInventory != null)
        {
            linkedInventory.onItemChangedCallback -= UpdateSlots;
        }
    }

    public void ChangeLinkedInventory(InventoryObject inventory)
    {
        UnsubscribeFromInventory();
        linkedInventory = inventory;
        SubscribeToInventory();
    }

    #endregion

    #region Controls

    void AddEvent(InventorySlotUI ui, EventTriggerType type, UnityAction<BaseEventData> action)
    {
        var eventTrigger = new EventTrigger.Entry();
        eventTrigger.eventID = type;
        eventTrigger.callback.AddListener(action);
        ui.GetComponent<EventTrigger>().triggers.Add(eventTrigger);
    }

    public void OnEnter(InventorySlotUI ui)
    {
        mouseItem.hoverObject = ui.gameObject;
        mouseItem.hoverItem = ui.representedItem;
    }

    public void OnExit(InventorySlotUI ui)
    {
        mouseItem.hoverObject = null;
        mouseItem.hoverItem = null;
    }

    public void OnDragStart(InventorySlotUI ui)
    {
        GameObject previewSprite = new GameObject();
        RectTransform rectTransform = previewSprite.AddComponent<RectTransform>();
        rectTransform.sizeDelta = ui.icon.rectTransform.sizeDelta;
        previewSprite.transform.SetParent(transform.parent);

        if (ui.representedItem.item != null)
        {
            Image image = previewSprite.AddComponent<Image>();
            image.sprite = ui.icon.sprite;
            image.raycastTarget = false;
        }

        mouseItem.currentObject = previewSprite;
        mouseItem.item = ui.representedItem;

    }

    public void OnDragEnd(InventorySlotUI ui)
    {
        if (mouseItem.hoverObject)
        {

            linkedInventory.MoveItem(mouseItem.item, mouseItem.hoverItem);
        }
        else
        {

        }

        Destroy(mouseItem.currentObject);
        mouseItem.item = null;
    }

    public void OnDrag(InventorySlotUI ui)
    {
        if (mouseItem.currentObject != null)
        {
            mouseItem.currentObject.GetComponent<RectTransform>().position = MenuManager.mousePosition;
        }
    }

    #endregion
}

public class MouseItem
{
    public GameObject currentObject;
    public InventorySlot item;
    public GameObject hoverObject;
    public InventorySlot hoverItem;
}

/*

Ok, so rant time. If my dictionary holds the index of the slot instead of the actual slot, 
I could pass that back without worrying about deleting the slots to resize the ui.
So I shouldn't store the Slots in the dictionary at all. I should only worry about their index, which can still be tracked via the list
And when I move items, it moves them within the dictionary. But how do I make new Items add properly to the dictionary. 
I could do a double for loop if need be and run through each inventory item and check that its in the dictionary at all
or the dictionary holds the items in the inventory and their index is the value.
Then I could check what spot I click on and move it to. Idk. That seems wrong.

*/