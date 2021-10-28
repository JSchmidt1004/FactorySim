using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Link
{
    public Pylon previous;
    public Pylon next;

    public float speed = 1;
    public float bounceHeight = 1;
    public float bounceSpeed = 1;

    public List<InventoryItem> items = new List<InventoryItem>();


    float timeSinceStart;

    public void MoveItems(bool lerpMovement = false, bool yBounce = false)
    {
        for (int i = 0; i < items.Count; i++)
        {
            InventoryItem item = items[i];

            Vector3 targetPosition = next.targetPostition.position;

            if (yBounce)
            {
                targetPosition.y += bounceHeight * Mathf.Sin(((Mathf.PI * 2) / bounceSpeed) * Time.time);
            }

            if (lerpMovement)
            {
                //Smooth movement between pylons
                item.transform.position = Vector3.Lerp(item.transform.position, targetPosition, speed * Time.deltaTime);
            }
            else
            {
                //Straight movement, no slowing down or anything
                item.transform.position = Vector3.MoveTowards(item.transform.position, targetPosition, speed * Time.deltaTime);
            }

            float distance = (item.transform.position - next.targetPostition.position).magnitude;

            if (distance <= next.itemRange)
            {
                next.OnReached(this, item);
                i--;
            }
        }
    }
}
