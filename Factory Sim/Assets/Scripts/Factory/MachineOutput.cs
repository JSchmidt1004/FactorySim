using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineOutput : MonoBehaviour
{
    public Factory connectedFactory;

    public bool isActive = false;

    void Update()
    {
        if (connectedFactory != null)
        {
            if (connectedFactory.chosenRecipe != null)
            {
                InventoryObject inventory = connectedFactory.connectedInventory;
                if (inventory != null)
                {
                    for(int i = 0; i < connectedFactory.connectedInventory.Container.Length; i++)
                    {
                        InventorySlot slot = connectedFactory.connectedInventory.Container[i];
                        if (slot.item == connectedFactory.chosenRecipe.outcome)
                        {
                            connectedFactory.connectedInventory.DropItem(slot, 1, transform.position);
                        }
                    }
                }
            }
        }
    }
}
