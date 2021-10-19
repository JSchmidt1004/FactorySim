using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BuildTool : Tool
{
    public List<Recipe> placeableRecipes = new List<Recipe>();

    public Material validMaterial;
    public Material invalidMaterial;

    public float rotateSpeed = 1;

    Camera playerCamera;
    Placeable chosenObject;
    GameObject preview;
    int index = 0;
    bool validPlacement = false;
    float previewRotation;

    #region PlayerInput

    protected override void PrimaryUse()
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

    protected override void SecondaryUse()
    {
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
    }

    public void OnScroll(InputValue value)
    {
        previewRotation += value.Get<Vector2>().y * rotateSpeed;
    }

    #endregion


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
                validPlacement = true;

                if (preview != null)
                {
                    if (altAction)
                    {
                        SnapPreview();
                    }
                    else
                    {
                        MovePreview(hit);
                        preview.transform.Rotate(Vector3.up, previewRotation);
                    }

                    validPlacement = CheckValidPlacement(hit);
                }
                else if (validPlacement)
                {
                    CreatePreview(chosenObject.previewModel);
                }
            }
            else
            {
                validPlacement = false;
                if (preview != null) Destroy(preview);
            }
        }
    }


    #region Selection

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
            chosenObject = null;
        }
    }

    #endregion

    #region PreviewControls

    void CreatePreview(GameObject model)
    {
        //Place the preview model into the world and adjust it so it isn't a full model
        preview = Instantiate(model);

        Transform[] previewTransforms = preview.GetComponentsInChildren<Transform>();

        foreach (Transform previewTransform in previewTransforms)
        {
            GameObject previewGO = previewTransform.gameObject;
            //Set to ignore raycast so that the preview doesn't fly towards our face from moving in front of itself
            previewGO.layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }

    void MovePreview(RaycastHit hit)
    {
        preview.transform.position = hit.point;
        preview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
    }

    void SnapPreview()
    {
        //Snap point A and B, and the transform

        //A is the place I want to be
        SnapPoint other = null;
        //B is the place that's snapping
        SnapPoint currentSnap = null;

        SnapPoint[] snapPoints = preview.GetComponentsInChildren<SnapPoint>();

        foreach (SnapPoint snapPoint in snapPoints)
        {
            other = snapPoint.CheckNearby();
            if (other != null)
            {
                currentSnap = snapPoint;
                break;
            }
        }

        if (other != null && currentSnap != null)
        {
            //I need the unnormalized "direction vector" from transform to B
            Vector3 offset = preview.transform.position - currentSnap.transform.position;


            //I need to move the transform to A plus the direction vector
            //(placedSnapPoint.position + (previewBase.position - previewSnapPoint.position))
            // A + (transform - B)
            preview.transform.position = other.transform.position + offset;



            //Then I need to rotate around A until I'm facing the direction of A's forward?
        }


    }

    #endregion

    #region PlacementValidity

    bool CheckValidPlacement(RaycastHit hit)
    {
        bool valid = true;

        //Checking angle of the building
        bool withinAngle = true;
        if (chosenObject.invertedPlacementAngle)
        {
            if (preview.transform.up.y > chosenObject.maxPlacementAngle) withinAngle = false;
        }
        else
        {
            if (preview.transform.up.y < chosenObject.maxPlacementAngle) withinAngle = false;
        }

        valid = (withinAngle); //Include && for other options

        //Change materials to reflect whether or not the object can be placed
        if (valid) ChangePreviewMaterials(validMaterial);
        else ChangePreviewMaterials(invalidMaterial);

        return valid; 
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

    #endregion

}
