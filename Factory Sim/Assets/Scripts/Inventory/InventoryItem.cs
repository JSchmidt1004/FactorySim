using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : MonoBehaviour
{
    public ItemObject item;

    void OnTriggerEnter(Collider other)
    {
        Backpack backpack = other.GetComponent<Backpack>();
        if (backpack != null)
        {
            backpack.inventory.AddItem(item, 1);
            Destroy(gameObject);
        }
    }
}
