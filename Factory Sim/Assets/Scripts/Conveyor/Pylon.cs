using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pylon : MonoBehaviour
{
    public Transform targetPostition;
    public float itemRange;
    public bool lerpMovement = false;
    public bool yBounce = true;

    public List<Link> nextLinks = new List<Link>();

    int outputIndex = 0;

    void Update()
    {
        foreach (Link link in nextLinks)
        {
            link.MoveItems(lerpMovement, yBounce);
        }
    }

    public void OnReached(Link from, GroundInventoryItem item)
    {
        RemoveFromLink(from, item);

        if (nextLinks.Count > 0)
        {
            int index = outputIndex % nextLinks.Count;
            outputIndex++;

            AddToLink(nextLinks[index], item);
        }
        else
        {
            Rigidbody rb = item.GetComponent<Rigidbody>();
            if (rb != null) rb.useGravity = true;
        }
    }

    void AddToLink(Link link, GroundInventoryItem item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null) rb.useGravity = false;

        link.items.Add(item);
    }

    void RemoveFromLink(Link link, GroundInventoryItem item)
    {
        link.items.Remove(item);
    }
}
