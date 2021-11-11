using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolObject", menuName = "ScriptableObjects/Items/Tool")]
public class ToolObject : ItemObject
{
    void Awake()
    {
        type = ItemType.Tool;   
    }
}
