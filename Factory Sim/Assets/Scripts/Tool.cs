using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public GameObject model;

    protected abstract void PrimaryUse();
    protected abstract void SecondaryUse();

    public virtual void OnPrimaryUse()
    {
        PrimaryUse();
    }

    public virtual void OnSecondaryUse()
    {
        SecondaryUse();
    }
}
