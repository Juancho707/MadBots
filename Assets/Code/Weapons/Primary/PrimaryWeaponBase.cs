using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public abstract class PrimaryWeaponBase : MonoBehaviour
{
    public PrimaryWeaponType WeaponType;
    public WeaponData Stats;
    protected float fireElapsed;

    public virtual void Fire()
    {
        
    }
}
