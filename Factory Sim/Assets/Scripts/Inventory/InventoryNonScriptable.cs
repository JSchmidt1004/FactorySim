using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InventoryNonScriptable : MonoBehaviour
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
        foreach (InventorySlot slot in Container)
        {
            if (slot.item == item)
            {
                int leftovers = slot.AddAmount(amount);

                if (leftovers > 0)
                {
                    amount = leftovers;
                    continue;
                }
                else
                {
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

    public int RemoveItem(InventorySlot slot, int amount)
    {
        int leftovers = slot.SubtractAmount(amount);

        if (leftovers >= 0)
        {
            onItemRemovedCallback?.Invoke(slot);
        }

        onItemChangedCallback?.Invoke();

        return leftovers;
    }

    public int SearchAndRemoveItem(ItemObject item, int amount)
    {
        for (int i = 0; i < Container.Length; i++)
        {
            InventorySlot slot = Container[i];
            if (slot.item == item)
            {
                return RemoveItem(slot, amount);
            }
        }

        return 0;
    }

    public void DropItem(InventorySlot slot, int amount, Vector3 position)
    {
        for (int i = 0; i < amount; i++)
        {
            Instantiate(slot.item.prefab, position, Quaternion.identity);
        }

        RemoveItem(slot, amount);
    }

    public void MoveItem(InventorySlot item1, InventorySlot item2)
    {
        InventorySlot temp = new InventorySlot(item2.item, item2.amount);

        if (item1.item == item2.item)
        {
            int leftover1 = item2.AddAmount(item1.amount);
            if (leftover1 > 0) item1.UpdateSlot(item1.item, leftover1);
            else item1.EmptySlot();
        }
        else
        {
            item2.UpdateSlot(item1.item, item1.amount);
            item1.UpdateSlot(temp.item, temp.amount);
        }

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
