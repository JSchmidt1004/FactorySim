using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public GameObject model;

    public abstract void PrimaryUse();
    public abstract void SecondaryUse();

    public virtual void OnPrimaryUse()
    {
        PrimaryUse();
    }

    public virtual void OnSecondaryUse()
    {
        Debug.Log("I am doing my secondary use");
        SecondaryUse();
    }
}
