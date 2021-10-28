using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultObject", menuName = "ScriptableObjects/Items/Default")]
public class DefaultObject : ItemObject
{
    void Awake()
    {
        type = ItemType.Default;   
    }
}
