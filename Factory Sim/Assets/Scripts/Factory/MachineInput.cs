using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineInput : MonoBehaviour
{
    public Factory connectedFactory;
    public bool isActive = false;

    public float range = 1.0f;
    public float checkTime = 1.0f;

    float timer = 0;

    void Update()
    {
        if (connectedFactory != null)
        {
            timer += Time.deltaTime;

            if (timer >= checkTime)
            {
                List<GroundInventoryItem> materials = FindMaterials();

                if (materials.Count > 0)
                {
                    PickUpMaterials(materials);
                }

                timer = 0;
            }
        }

    }

    public List<GroundInventoryItem> FindMaterials()
    {
        float halfExtents = range / 2;
        Collider[] colliders = Physics.OverlapBox(transform.position, new Vector3(halfExtents, halfExtents, halfExtents), transform.rotation);

        List<GroundInventoryItem> materials = new List<GroundInventoryItem>();

        foreach (Collider collider in colliders)
        {
            GroundInventoryItem material = collider.gameObject.GetComponent<GroundInventoryItem>();
            if (material?.item != null)
            {
                
                materials.Add(material);
                
            }
        }

        return materials;
    }

    void PickUpMaterials(List<GroundInventoryItem> materials)
    {
        for(int i = 0; i < materials.Count; i++)
        {
            GroundInventoryItem material = materials[i];
            connectedFactory.connectedInventory?.AddItem(material.item, 1);
            //if (material.destroyOnGrab) Destroy(material.gameObject);
        }
    }
}
