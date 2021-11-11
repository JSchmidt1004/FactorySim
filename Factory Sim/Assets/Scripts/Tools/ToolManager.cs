using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public Tool currentTool;
    public Transform toolSpawn;

    static GameObject spawnedModel;

    public void Equip(Tool tool)
    {
        currentTool = tool;
        spawnedModel = Instantiate(tool.model, toolSpawn);
    }

    public void Unequip()
    {
        Destroy(spawnedModel);
    }
}
