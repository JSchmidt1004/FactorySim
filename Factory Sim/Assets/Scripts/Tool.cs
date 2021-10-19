using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public GameObject model;
    protected bool altAction = false;

    protected abstract void PrimaryUse();
    protected abstract void SecondaryUse();

    protected virtual void AltPrimaryUse()
    {
        PrimaryUse();
    }
    protected virtual void AltSecondaryUse()
    {
        SecondaryUse();
    }
    
    public virtual void OnPrimaryUse()
    {
        if (altAction) AltPrimaryUse();
        else PrimaryUse();
    }

    public virtual void OnSecondaryUse()
    {
        if (altAction) AltSecondaryUse();
        else SecondaryUse();
    }

    public virtual void OnAltAction()
    {
        altAction = !altAction;
    }
}
