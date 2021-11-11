using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RadialMenu : MonoBehaviour
{
    public GameObject entryPrefab;
    public InventoryObject hotbar;
    public ToolManager toolManager;

    public float radius = 3;

    List<RadialMenuEntry> entries = new List<RadialMenuEntry>();

    void AddEntry(string label, Sprite sprite, InventorySlot slot)
    {
        GameObject entry = Instantiate(entryPrefab, transform);

        RadialMenuEntry menuEntry = entry.GetComponent<RadialMenuEntry>();
        menuEntry.SetLabel(label);
        menuEntry.SetIcon(sprite);
        menuEntry.SetRepresentedItem(slot);
        menuEntry.onItemClickedCallback += OnClicked;

        entries.Add(menuEntry);
    }

    public void Open()
    {
        if (hotbar != null)
        {
            foreach (InventorySlot slot in hotbar.Container)
            {
                if (slot != null) AddEntry(slot.item?.name, slot.item?.icon, slot);
            }
        }

        Rearrange();
    }

    public void Close()
    {
        for (int i = 0; i < entries.Count; i++)
        {
            RectTransform rect = entries[i].GetComponent<RectTransform>();
            GameObject entry = entries[i].gameObject;

            rect.DOAnchorPos(Vector3.zero, 0.3f).SetEase(Ease.OutQuad).onComplete = 
                delegate()
                {
                    Destroy(entry);
                };

        }

        entries.Clear();
    }

    public void Toggle()
    {
        if (entries.Count > 0) Close();
        else Open();
    }

    void Rearrange()
    {
        float radiansOfSeparation = (Mathf.PI * 2) / entries.Count;
        for(int i = 0; i < entries.Count; i++)
        {
            float x = Mathf.Sin(radiansOfSeparation * i) * radius;
            float y = Mathf.Cos(radiansOfSeparation * i) * radius;

            RectTransform rect = entries[i].GetComponent<RectTransform>();

            rect.localScale = Vector3.zero;
            rect.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutQuad).SetDelay(0.05f * i);
            rect.DOAnchorPos(new Vector3(x, y, 0), 0.3f).SetEase(Ease.OutQuad).SetDelay(0.05f * i);
        }
    }

    void OnClicked(RadialMenuEntry entry)
    {
        InventorySlot item = entry.representedItem;

        if (item.item?.type == ItemType.Tool)
        {
            toolManager?.Equip(item.item.prefab?.GetComponent<Tool>());
        }
        else
        {
            toolManager?.Unequip();
        }
    }
}
