using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    public InventoryObject connectedInventory;
    public List<Recipe> availableRecipes = new List<Recipe>();
    public Recipe chosenRecipe;
    public MachineInput input;
    public MachineOutput output;

    protected float timer = 0;

    void Start()
    {
        SetRecipe(availableRecipes[0]);
    }

    void Update()
    {
        CraftUpdate();
    }

    protected void CraftUpdate()
    {
        if (chosenRecipe != null)
        {
            timer += Time.deltaTime;

            if (timer >= chosenRecipe.craftTime)
            {
                Crafting.Craft(chosenRecipe, connectedInventory);
                timer = 0;
            }
        }
    }

    public void SetRecipe(Recipe recipe)
    {
        chosenRecipe = recipe;
        input.isActive = true;
        output.isActive = true;
    }

    public void RemoveRecipe()
    {
        chosenRecipe = null;
        input.isActive = false;
        output.isActive = false;
    }
}
