using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Backpack : MonoBehaviour
{
    public InventoryObject inventory;

    void GetItemFromWorld()
    {
        //I need to have some way to interact and add items that way. I'm using a temporary setup right now
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();
    }
}
