using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipes/Recipe")]
public class Recipe : ScriptableObject
{
    public string RecipeName = "Default Recipe";
    public float craftTime = 0.5f;

    public ItemObject outcome;

    public List<ExpectedResource> expectedResources;
}

[Serializable]
public class ExpectedResource
{
    public InventorySlot resourceObject;
    public int count = 1;
}
