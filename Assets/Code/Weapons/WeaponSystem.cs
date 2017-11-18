using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class WeaponSystem : MonoBehaviour
{
    [HideInInspector] public WeaponBase[] PrimaryWeapon;
    [HideInInspector] public WeaponBase[] SecondaryWeapon;

    public Transform PrimaryWeaponSpot;
    public Transform SecondaryWeaponSpot;

    void Start()
    {
        PrimaryWeapon = PrimaryWeaponSpot.GetComponentsInChildren<WeaponBase>();
        SecondaryWeapon = SecondaryWeaponSpot.GetComponentsInChildren<WeaponBase>();
    }
}
