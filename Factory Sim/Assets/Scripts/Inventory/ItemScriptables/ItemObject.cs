using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Default,
    Tool,
    Material
}

public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;

    public Sprite icon;
    public ItemType type = ItemType.Default;
    public int maxStack = 100;

    [TextArea(15, 20)]
    public string description;
}
