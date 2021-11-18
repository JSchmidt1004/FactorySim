using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildTool : Tool
{
    public List<Recipe> placeableRecipes = new List<Recipe>();

    public bool requireResources = true;

    Camera playerCamera;
    Placement placement;

    Recipe currentRecipe;
    bool validPlacement;
    int index = 0;

    #region PlayerInput

    protected override void PrimaryUse()
    {
        placement.Place(validPlacement);
        validPlacement = false;
    }

    protected override void SecondaryUse()
    {
        //TEMPORARY USE
        //Plan to implement UI for this later. Secondary Use will likely be to destroy buildings
        //It's better to have them all in one tool than to make people switch I think

        //Swap between all of the recipes with a simple right click
        if (placeableRecipes.Count > 0)
        {
            int current = index % placeableRecipes.Count;
            currentRecipe = placeableRecipes[current];
            GameObject chosen = currentRecipe.outcome.prefab;
            placement.SelectChosen(chosen.GetComponent<Placeable>());
            index++;
        }
    }

    public void OnScroll(InputValue value)
    {
        placement.Rotate(value.Get<Vector2>().y);
    }

    #endregion

    #region UnityDefaults

    void Start()
    {
        playerCamera = Camera.main;
        placement = GetComponent<Placement>();
    }

    void Update()
    {
        if (placement.chosenActive)
        {
            RaycastHit hit;
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            if (Physics.Raycast(ray, out hit, 10f))
            {
                validPlacement = true;

                if (placement.previewActive)
                {
                    if (altAction)
                    {
                        placement.SnapPreview();
                    }
                    else
                    {
                        placement.MovePreview(hit);
                       
                    }

                    validPlacement = placement.CheckValidPlacement(hit, HasRecipeResources());
                }
                else if (validPlacement)
                {
                    placement.SelectChosen(currentRecipe.outcome.prefab.GetComponent<Placeable>());
                }
            }
            else
            {
                validPlacement = false;
                placement.DestroyPreview();
            }
        }
    }

    void OnDestroy()
    {
        placement.DestroyPreview();
    }

    #endregion

    bool HasRecipeResources()
    {
        if (requireResources)
        {
            return Crafting.HasIngredients(currentRecipe, PlayerInfo.backpack?.inventoryMenus[0].linkedInventory);
        }

        return true;
    }

}
