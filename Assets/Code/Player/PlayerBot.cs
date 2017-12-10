﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerBot : MonoBehaviour
{
    public Nationality Country;
    public BotData Stats;
    public int PlayerId;
    public int CurrentHealth;
    public LowerPartMovement LowerController;
    public UpperPartMovement UpperController;
    [HideInInspector] public WeaponSystem Weapons;

    void Start()
    {
        CurrentHealth = Stats.MaxHealth;
        LowerController.RollSpeed = Stats.SpeedScore;
        LowerController.TurnSpeed = Stats.TurnScore;
        UpperController.TurnSpeed = Stats.TurretRotateScore;
    }

    public void LoadPrimary(GameObject weapon)
    {
        Weapons = this.GetComponentInChildren<WeaponSystem>();
        Weapons.LoadPrimary(weapon);
    }

    public void LoadSecondary(GameObject weapon)
    {
        Weapons = this.GetComponentInChildren<WeaponSystem>();
        Weapons.LoadSecondary(weapon);
    }
}
