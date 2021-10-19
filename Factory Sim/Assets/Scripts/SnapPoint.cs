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

    private void OnDrawGizmos()
    {
        //Gizmos.DrawCube(transform.position, new Vector3(distance / 2, distance / 2, distance / 2));
    }

    public SnapPoint CheckNearby()
    {
        List<SnapPoint> nearbyPoints = GetNearbySnapPoints();

        SnapPoint other = null;

        switch (snapType)
        {
            case eType.General:
                other = CheckGeneral(nearbyPoints);
                break;
            case eType.Input:
                other = CheckInput(nearbyPoints);
                break;
            case eType.Output:
                other = CheckOutput(nearbyPoints);
                break;
            case eType.ConveyorStart:
                other = CheckConveyorStart(nearbyPoints);
                break;
            case eType.ConveyorEnd:
                other = CheckConveyorEnd(nearbyPoints);
                break;
            default:
                other = CheckGeneral(nearbyPoints);
                break;
        }

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

    SnapPoint CheckGeneral(List<SnapPoint> nearbyPoints)
    {
        foreach (SnapPoint point in nearbyPoints)
        {
            if (point.snapType == eType.General) return point;
        }

        return null;
    }

    SnapPoint CheckInput(List<SnapPoint> nearbyPoints)
    {
        foreach(SnapPoint point in nearbyPoints)
        {
            if (point.snapType == eType.Output) return point;
        }

        return null;
    }

    SnapPoint CheckOutput(List<SnapPoint> nearbyPoints)
    {
        foreach (SnapPoint point in nearbyPoints)
        {
            if (point.snapType == eType.Input) return point;
        }

        return null;
    }

    SnapPoint CheckConveyorStart(List<SnapPoint> nearbyPoints)
    {
        foreach (SnapPoint point in nearbyPoints)
        {
            if (point.snapType == eType.Output) return point;
        }

        return null;
    }

    SnapPoint CheckConveyorEnd(List<SnapPoint> nearbyPoints)
    {
        foreach (SnapPoint point in nearbyPoints)
        {
            if (point.snapType == eType.Input) return point;
        }

        return null;
    }
}
