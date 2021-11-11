using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;

    public InventorySlot()
    {
        item = null;
        amount = 0;
    }

    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void AddAmount(int value)
    {
        amount += value;
    }

    public void UpdateSlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }
}
