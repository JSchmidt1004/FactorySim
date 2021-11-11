using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public List<Tool> tools = new List<Tool>();
    public Tool currentTool;

    public Transform toolSpawn;

    GameObject spawnedModel;

    void Start()
    {
        if (tools.Count > 0)
        {
            currentTool = tools[0];
            Equip();
        }    
    }

    public virtual void Equip()
    {
        spawnedModel = Instantiate(currentTool.model, toolSpawn);
    }

    public virtual void Unequip()
    {
        Destroy(spawnedModel);
    }
}
