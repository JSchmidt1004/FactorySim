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
    LineRenderer lineRenderer;

    float previewRotation;

    public void Place(bool validPlacement)
    {
        if (previewActive)
        {
            if (validPlacement)
            {
                Transform location = preview.transform;
                Placeable placedObject = Instantiate(chosenObject, location.position, location.rotation);

                if (placedObject.Type == Placeable.eType.Factory)
                {
                    Factory factory = placedObject.GetComponent<Factory>();
                    if (factory != null)
                    {
                        factory.connectedInventory = ScriptableObject.CreateInstance<InventoryObject>();
                        factory.connectedInventory.slotCount = factory.connectedInventory.Container.Length;
                    }
                }

            }
        }
    }

    public void Rotate(float direction)
    {
        previewRotation += direction * rotateSpeed;
    }

    #region UnityDefaults

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.enabled = false;
    }

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

        if (chosenObject.Type == Placeable.eType.Conveyor)
        {
            lineRenderer.enabled = true;
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    public void DestroyPreview()
    {
        if (previewActive)
        {
            Destroy(preview);
            if (chosenObject.Type == Placeable.eType.Conveyor)
            {
                lineRenderer.enabled = false;
            }
        }
    }

    public void MovePreview(RaycastHit hit)
    {
        preview.transform.position = hit.point;
        preview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);

        if (chosenObject.Type == Placeable.eType.Conveyor) SetupCircle();
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

    private void SetupCircle()
    {
        lineRenderer.widthMultiplier = 0.05f;
        int vertexCount = 30;

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(chosenObject.radius * Mathf.Cos(theta), 0.5f, chosenObject.radius * Mathf.Sin(theta));
            lineRenderer.SetPosition(i, preview.transform.position + pos);
            theta += deltaTheta;
        }

    }
}
