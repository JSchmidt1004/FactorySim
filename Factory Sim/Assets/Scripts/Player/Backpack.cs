using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : InventoryManager
{
    public InventoryObject hotbar;

    public GameObject hotbarMenu;

    void Start()
    {
        FillSlots(inventory, InventoryMenu);
        FillSlots(hotbar, hotbarMenu);
    }

    public void UpdateSlots()
    {
        for (int i = 0; i < inventory.Container.Count; i++)
        {
            InventorySlot item = inventory.Container[i];

            slotUIs[i].ActivateIconAndCount(item.item.icon, item.amount);
        }
    }

    void GetItemFromWorld()
    {
        //I need to have some way to interact and add items that way. I'm using a temporary setup right now
    }

    private void OnApplicationQuit()
    {
        //inventory.Container.Clear();
    }
}
