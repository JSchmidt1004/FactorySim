using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTool : Tool
{
    public List<Recipe> placeableRecipes = new List<Recipe>();

    Camera playerCamera;
    Placeable chosenObject;
    GameObject preview;
    int index = 0;

    public override void PrimaryUse()
    {
        throw new System.NotImplementedException();
    }

    public override void SecondaryUse()
    {
        //TEMPORARY USE
        //Plan to implement UI for this later. Secondary Use will likely be to destroy buildings
        //It's better to have them all in one tool than to make people switch I think

        if (placeableRecipes.Count > 0)
        {
            int current = index % placeableRecipes.Count;
            GameObject chosen = placeableRecipes[current].outcome;
            SelectChosen(chosen.GetComponent<Placeable>());
            index++;
        }
    }

    void Start()
    {
        playerCamera = Camera.main;   
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);

        if (Physics.Raycast(ray, out hit))
        {
            //hit.point to get the position. NOT hit.transform.position
        }

    }

    public void SelectChosen(Placeable placeable)
    {
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
            if (preview != null) Destroy(preview);
            chosenObject = null;
        }
    }

    public void CreatePreview(GameObject model)
    {
        preview = Instantiate(model);

        Transform[] previewTransforms = preview.GetComponentsInChildren<Transform>();

        foreach (Transform previewTransform in previewTransforms)
        {
            GameObject previewGO = previewTransform.gameObject;
            previewGO.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }

    void ChangePreviewMaterials(Material currentMat)
    {
        if (currentMat != null)
        {
            Renderer[] previewMaterials = preview.GetComponentsInChildren<Renderer>();

            for (int i = 0; i < previewMaterials.Length; i++)
            {
                previewMaterials[i].material = currentMat;
            }
        }
    }
}
