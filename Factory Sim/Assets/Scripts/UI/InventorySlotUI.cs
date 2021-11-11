using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text countText;

    public void ActivateIconAndCount(Sprite sprite, int count)
    {
        icon.sprite = sprite;
        countText.text = count.ToString();

        icon.gameObject.SetActive(true);
        countText.gameObject.SetActive(true);
    }


    public void DeactivateIconAndCount()
    {
        icon.enabled = false;
        countText.enabled = false;
    }
}
