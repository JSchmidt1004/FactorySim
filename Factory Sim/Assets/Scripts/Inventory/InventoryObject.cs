using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Inventory", menuName = "ScriptableObjects/Inventory")]
public class InventoryObject : ScriptableObject
{
    public int slotCount;

    public InventorySlot[] Container = new InventorySlot[9];

    public delegate void OnItemAdded();
    public OnItemAdded onItemAddedCallback;

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public delegate void OnItemRemoved(InventorySlot slot);
    public OnItemRemoved onItemRemovedCallback;

    public void Awake()
    {
        if (slotCount > 0) Container = new InventorySlot[slotCount];
        for (int i = 0; i < Container.Length; i++)
        {
            Container[i] = new InventorySlot();
        }
    }

    public bool AddItem(ItemObject item, int amount)
    {
        foreach(InventorySlot slot in Container)
        {
            if (slot.item == item)
            {
                if (slot.amount + amount > slot.item.maxStack)
                {
                    int spaceLeft = slot.item.maxStack - slot.amount;
                    amount -= spaceLeft;
                    slot.AddAmount(spaceLeft);
                    continue;
                }
                else
                {
                    slot.AddAmount(amount);
                    onItemAddedCallback?.Invoke();
                    onItemChangedCallback?.Invoke();
                    return true;
                }
            }
        }

        int index = FindFirstEmpty();
        if (index >= 0 && index < Container.Length)
        {
            Container[index] = new InventorySlot(item, amount);
            onItemAddedCallback?.Invoke();
            return true;
        }

        return false;
    }

    public void RemoveItem(ItemObject item, int amount)
    {
        for (int i = 0; i < Container.Length; i++)
        {
            InventorySlot slot = Container[i];
            if (slot.item == item)
            {
                if (amount < slot.amount)
                {
                    slot.amount -= amount;
                }
                else
                {
                    onItemRemovedCallback?.Invoke(slot);
                    slot = new InventorySlot();
                    slot.item = null;
                }

                onItemChangedCallback?.Invoke();

                return;
            }
        }
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.item, item2.amount);

        item2.UpdateSlot(item1.item, item1.amount);
        item1.UpdateSlot(temp.item, temp.amount);


        onItemChangedCallback?.Invoke();
    }

    public int FindFirstEmpty()
    {
        for (int i = 0; i < Container.Length; i++)
        {
            if (Container[i].item == null) return i;
        }

        return -1;
    }
}
