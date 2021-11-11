using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RadialMenuEntry : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public delegate void onItemClicked(RadialMenuEntry entry);
    public onItemClicked onItemClickedCallback;

    public TextMeshProUGUI Label;
    public Image icon;
    public InventorySlot representedItem;

    RectTransform rect;

    #region UnityDefaults

    void Start()
    {
        rect = icon.GetComponent<RectTransform>();
    }

    #endregion

    public void SetLabel(string text)
    {
        Label.text = (text != null) ? text : "";
    }

    public void SetIcon(Sprite sprite)
    {
        icon.sprite = (sprite != null) ? sprite : icon.sprite;
    }

    public void SetRepresentedItem(InventorySlot item)
    {
        representedItem = item;
    }

    public Image GetIcon()
    {
        return icon;
    }

    #region PointerHandlers

    public void OnPointerClick(PointerEventData eventData)
    {
        onItemClickedCallback?.Invoke(this);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rect.DOComplete();
        rect.DOScale(Vector3.one * 1.5f, 0.3f).SetEase(Ease.OutQuad);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        rect.DOComplete();
        rect.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutQuad);
    }

    #endregion
}
