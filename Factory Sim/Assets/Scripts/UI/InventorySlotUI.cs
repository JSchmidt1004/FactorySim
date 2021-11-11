using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text countText;
    public InventorySlot representedItem;

    public void ActivateIconAndCount(Sprite sprite, int count)
    {
        icon.sprite = sprite;
        countText.text = count.ToString();

        icon.gameObject.SetActive(true);
        if (count > 1) countText.gameObject.SetActive(true);
        else countText.gameObject.SetActive(false);
    }

    public void DeactivateIconAndCount()
    {
        icon.gameObject.SetActive(false);
        countText.gameObject.SetActive(false);
    }
}
