using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placement : MonoBehaviour
{
    public Material validMaterial;
    public Material invalidMaterial;
    public float rotateSpeed = 1;

    public bool chosenActive { get { return (chosenObject != null); } }
    public bool previewActive { get { return (preview != null); } }

    Placeable chosenObject;
    GameObject preview;

    float previewRotation;

    public void Place(bool validPlacement)
    {
        if (previewActive)
        {
            if (validPlacement)
            {
                Transform location = preview.transform;
                Instantiate(chosenObject, location.position, location.rotation);
            }
        }
    }

    public void Rotate(float direction)
    {
        previewRotation += direction * rotateSpeed;
    }

    #region UnityDefaults

    void Update()
    {

        if (previewActive) preview.transform.Rotate(Vector3.up, previewRotation);
    }

    #endregion

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

    public void DestroyPreview()
    {
        if (previewActive) Destroy(preview);
    }

    public void MovePreview(RaycastHit hit)
    {
        preview.transform.position = hit.point;
        preview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
    }

    public void SnapPreview()
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
            // A + (transform - B)
            preview.transform.position = other.transform.position + offset;

            //Then I need to rotate around A until I'm facing the direction of A's forward?
            float angle = Vector3.Angle(currentSnap.transform.forward, other.transform.forward);
            preview.transform.RotateAround(other.transform.position, Vector3.up, angle);
        }
    }

    #endregion

    #region PlacementValidity

    public bool CheckValidPlacement(RaycastHit hit, bool other = true)
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

        valid = (withinAngle && other);

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
