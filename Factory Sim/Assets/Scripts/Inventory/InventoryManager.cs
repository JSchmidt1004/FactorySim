using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryObject inventory;

    public GameObject InventoryMenu;
    public GameObject InventorySlotUI;

    protected List<InventorySlotUI> slotUIs = new List<InventorySlotUI>();

    protected void FillSlots(InventoryObject inventory, GameObject menu)
    {
        if (menu != null && InventorySlotUI != null)
        {
            for(int i = 0; i < inventory.slotCount; i++)
            {
                GameObject slotUI = Instantiate(InventorySlotUI, menu.transform);
                slotUIs.Add(slotUI.GetComponent<InventorySlotUI>());
            }
        }
    }
}
