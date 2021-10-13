using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public GameObject model;
    public Transform toolSpawn;

    GameObject spawnedModel;

    public abstract void PrimaryUse();
    public abstract void SecondaryUse();

    //public virtual void Equip()
    //{
    //    spawnedModel = Instantiate(model, toolSpawn);
    //}

    //public virtual void Unequip()
    //{
    //    Destroy(spawnedModel);
    //}

    public virtual void OnPrimaryUse()
    {
        PrimaryUse();
    }

    public virtual void OnSecondaryUse()
    {
        SecondaryUse();
    }
}
