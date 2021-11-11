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

    public void OnReached(Link from, InventoryItem item)
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

    void AddToLink(Link link, InventoryItem item)
    {
        Rigidbody rb = item.GetComponent<Rigidbody>();
        if (rb != null) rb.useGravity = false;

        link.items.Add(item);
    }

    void RemoveFromLink(Link link, InventoryItem item)
    {
        link.items.Remove(item);
    }
}
