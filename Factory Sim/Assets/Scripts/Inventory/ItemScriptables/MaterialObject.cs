using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialObject", menuName = "ScriptableObjects/Items/Material")]
public class MaterialObject : ItemObject
{
    void Awake()
    {
        type = ItemType.Material;   
    }
}
