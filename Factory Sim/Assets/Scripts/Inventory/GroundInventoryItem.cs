using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundInventoryItem : MonoBehaviour
{
    public ItemObject item;
    public bool destroyOnGrab = true;

    void OnTriggerEnter(Collider other)
    {
        if (destroyOnGrab)
        {
            Backpack backpack = other.GetComponent<Backpack>();
            if (backpack != null)
            {
                if (backpack.inventoryMenus.Count > 0)
                {
                    bool success = backpack.inventoryMenus[0].linkedInventory.AddItem(item, 1);
                    if (success) Destroy(gameObject);
                }
            }
        }
    }
}
