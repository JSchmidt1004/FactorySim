using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTool : Tool
{
    public List<Recipe> placeableRecipes = new List<Recipe>();

    public Material validMaterial;
    public Material invalidMaterial;

    Camera playerCamera;
    Placeable chosenObject;
    GameObject preview;
    int index = 0;
    bool validPlacement = false;

    public override void PrimaryUse()
    {
        if (preview != null)
        {
            if(validPlacement)
            {
                Transform location = preview.transform;
                Instantiate(chosenObject, location.position, location.rotation);
                validPlacement = false;
            }
        }
    }

    public override void SecondaryUse()
    {
        Debug.Log("I am choosing an object");

        //TEMPORARY USE
        //Plan to implement UI for this later. Secondary Use will likely be to destroy buildings
        //It's better to have them all in one tool than to make people switch I think

        //Swap between all of the recipes with a simple right click
        if (placeableRecipes.Count > 0)
        {
            int current = index % placeableRecipes.Count;
            GameObject chosen = placeableRecipes[current].outcome;
            SelectChosen(chosen.GetComponent<Placeable>());
            index++;
        }

        Debug.Log("I have chosen an object: " + chosenObject.name);
    }

    void Start()
    {
        playerCamera = Camera.main;   
    }

    void Update()
    {
        if (chosenObject != null)
        {
            RaycastHit hit;
            Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

            if (Physics.Raycast(ray, out hit, 10f))
            {
                //hit.point to get the position. NOT hit.transform.position
            }
        }
    }

    public void SelectChosen(Placeable placeable)
    {
        //Deselect before selecting to ensure nothing stays from before
        if (chosenObject != null) DeselectChosen();

        chosenObject = placeable;
        if (chosenObject != null)
        {
            CreatePreview(chosenObject.previewModel);
        }
    }

    public void DeselectChosen()
    {
        if (chosenObject != null)
        {
            //Remove everything to create a fresh start
            if (preview != null) Destroy(preview);
            preview = null;
            chosenObject = null;
        }
    }

    void CreatePreview(GameObject model)
    {
        //Place the preview model into the world and adjust it so it isn't a full model
        preview = Instantiate(model);

        Transform[] previewTransforms = preview.GetComponentsInChildren<Transform>();

        foreach (Transform previewTransform in previewTransforms)
        {
            GameObject previewGO = previewTransform.gameObject;
            //Remove colliders to avoid hitting materials and such and ruining the factory flow
            previewGO.GetComponent<Collider>().enabled = false;
            //Set to ignore raycast so that the preview doesn't fly towards our face from moving in front of itself
            previewGO.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }


    void MovePreview()
    {

    }

    bool CheckValidPlacement()
    {
        bool validPlacement = true;

        

        //Change materials to reflect whether or not the object can be placed
        if (validPlacement) ChangePreviewMaterials(validMaterial);
        else ChangePreviewMaterials(invalidMaterial);

        return validPlacement;
    }

    void ChangePreviewMaterials(Material currentMat)
    {
        if (currentMat != null)
        {
            Renderer[] previewMaterials = preview.GetComponentsInChildren<Renderer>();

            //Change the materials on every renderer in the heirarchy for full ghostliness
            for (int i = 0; i < previewMaterials.Length; i++)
            {
                previewMaterials[i].material = currentMat;
            }
        }
    }
}
