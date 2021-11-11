using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInventoryItem : MonoBehaviour
{
    public ItemObject item;

    void OnTriggerEnter(Collider other)
    {
        Backpack backpack = other.GetComponent<Backpack>();
        if (backpack != null)
        {
            bool success = backpack.inventoryMenus[0].linkedInventory.AddItem(item, 1);
            if (success) Destroy(gameObject);
        }
    }
}
