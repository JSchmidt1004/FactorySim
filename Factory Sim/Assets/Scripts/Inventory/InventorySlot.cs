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
        EmptySlot();
    }

    public InventorySlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public int AddAmount(int value)
    {
        int availableSpace = item.maxStack - amount;
        int leftovers = value - availableSpace;

        if (amount + value > item.maxStack) amount = item.maxStack;
        else amount += value;

        //amount += value;

        return leftovers;
    }

    public int SubtractAmount(int value)
    {
        int leftovers = -(amount - value);

        if (amount - value < 0) EmptySlot();
        else amount -= value;

        return leftovers;
    }

    public void UpdateSlot(ItemObject item, int amount)
    {
        this.item = item;
        this.amount = amount;
    }

    public void EmptySlot()
    {
        item = null;
        amount = 0;
    }
}
