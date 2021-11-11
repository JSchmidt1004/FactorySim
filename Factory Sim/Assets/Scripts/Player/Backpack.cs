using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public List<InventoryMenu> inventoryMenus = new List<InventoryMenu>();

    void Awake()
    {
        for(int i = 0; i < inventoryMenus.Count; i++)
        {
            inventoryMenus[i].CreateSlots();
        }
    }

    void Start()
    {
        for(int i = 0; i < inventoryMenus.Count; i++)
        {
            inventoryMenus[i].SubscribeToInventory();
            inventoryMenus[i].UpdateSlots();
        }
    }
}
