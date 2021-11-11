using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Recipe", menuName = "ScriptableObjects/Recipes/Recipe")]
public class Recipe : ScriptableObject
{
    [Serializable]
    public class ExpectedResource
    {
        public string name = "Default Resource";
        //public Resource resourceObject
        public int count = 1;
    }

    public string RecipeName = "Default Recipe";
    public float craftTime = 0.5f;

    public GameObject outcome;

    public ExpectedResource[] expectedResources;
}
