using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Crafting
{

    public static bool HasIngredients(Recipe chosenRecipe, InventoryObject inventory)
    {
        for (int i = 0; i < chosenRecipe?.expectedResources.Count; i++)
        {
            ExpectedResource resource = chosenRecipe?.expectedResources[i];
            bool hasItem = HasItem(inventory, resource);

            if (!hasItem) return false;
        }

        return true;
    }

    public static bool HasItem(InventoryObject inventory, ExpectedResource resource)
    {
        int foundCount = 0;

        for (int i = 0; i < inventory.Container.Length; i++)
        {
            InventorySlot slot = inventory.Container[i];
            if (slot.item == resource.resourceObject.item)
            {
                foundCount += slot.amount;
            }
        }

        return (foundCount >= resource.count);
    }

    public static void Craft(Recipe chosenRecipe, InventoryObject inventory)
    {
        if (HasIngredients(chosenRecipe, inventory))
        {
            CreateItem(chosenRecipe, inventory);
        }
    }

    public static void CreateItem(Recipe chosenRecipe, InventoryObject inventory, bool removeResources = true)
    {
        if (removeResources)
        {
            for (int i = 0; i < chosenRecipe?.expectedResources.Count; i++)
            {
                ExpectedResource resource = chosenRecipe?.expectedResources[i];

                int leftovers = 1;
                while (leftovers > 0)
                {
                    leftovers = inventory.SearchAndRemoveItem(resource.resourceObject.item, resource.count);
                }
            }
        }

        inventory.AddItem(chosenRecipe.outcome, 1);
    }
}
