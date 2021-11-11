using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapPoint : MonoBehaviour
{
    public enum eType
    {
        General,
        Input,
        Output,
        ConveyorStart,
        ConveyorEnd
    }

    public eType snapType = eType.General;
    public float distance = 1.0f;


    public SnapPoint CheckNearby()
    {
        List<SnapPoint> nearbyPoints = GetNearbySnapPoints();

        List<eType> compatibleTypes = new List<eType>();

        switch (snapType)
        {
            case eType.General:
                compatibleTypes.Add(eType.General);
                break;
            case eType.Input:
                compatibleTypes.Add(eType.Output);
                compatibleTypes.Add(eType.ConveyorEnd);
                break;
            case eType.Output:
                compatibleTypes.Add(eType.Input);
                compatibleTypes.Add(eType.ConveyorStart);
                break;
            case eType.ConveyorStart:
                compatibleTypes.Add(eType.Output);
                compatibleTypes.Add(eType.ConveyorEnd);
                break;
            case eType.ConveyorEnd:
                compatibleTypes.Add(eType.Input);
                compatibleTypes.Add(eType.ConveyorStart);
                break;
            default:
                compatibleTypes.Add(eType.General);
                break;
        }

        SnapPoint other = CheckPoints(nearbyPoints, compatibleTypes);

        return other;
    }

    List<SnapPoint> GetNearbySnapPoints()
    {
        float halfExtents = distance / 2;
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(halfExtents, halfExtents, halfExtents), transform.rotation);

        List<SnapPoint> nearbyPoints = new List<SnapPoint>();

        foreach(Collider collider in colliders)
        {
            SnapPoint snapPoint = collider.gameObject.GetComponent<SnapPoint>();
            if (snapPoint != null)
            {
                if (snapPoint.gameObject != this.gameObject)
                {
                    nearbyPoints.Add(snapPoint);
                }
            }
        }

        return nearbyPoints;
    }

    SnapPoint CheckPoints(List<SnapPoint> nearbyPoints, List<eType> compatibleTypes)
    {
        foreach(SnapPoint point in nearbyPoints)
        {
            foreach (eType type in compatibleTypes)
            {
                if (point.snapType == type) return point;
            }
        }

        return null;
    }

}
