using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Condenser : Factory
{
    void Start()
    {
        List<GroundInventoryItem> materials = input.FindMaterials();
        foreach(Recipe recipe in availableRecipes)
        {
            foreach (ExpectedResource expectedResource in recipe.expectedResources)
            {
                foreach(GroundInventoryItem material in materials)
                {
                    if (expectedResource.resourceObject.item == material.item)
                    {
                        SetRecipe(recipe);
                        return;
                    }
                }

            }
        }
    }

    void Update()
    {
        CraftUpdate();
    }
}
