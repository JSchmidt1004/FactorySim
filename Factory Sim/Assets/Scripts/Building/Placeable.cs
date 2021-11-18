using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placeable : MonoBehaviour
{
    public enum eType
    {
        Factory,
        Conveyor,
        Building
    }

    public eType Type;

    [Range(-1f, 1f)]
    public float maxPlacementAngle = 0.75f;
    public bool invertedPlacementAngle;
    public List<SnapPoint> snapPoints = new List<SnapPoint>();
    public float radius = 2f;

    public GameObject previewModel;


}
