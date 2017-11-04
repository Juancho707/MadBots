using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerBot : MonoBehaviour
{
    public BotData Stats;
    public int PlayerId;
    public int CurrentHealth;
    public LowerPartMovement LowerController;
    public UpperPartMovement UpperController;
    public WeaponBase PrimaryWeapon;
    public WeaponBase SecondaryWeapon;

    void Start()
    {
        CurrentHealth = Stats.MaxHealth;
        LowerController.RollSpeed = Stats.SpeedScore;
        LowerController.TurnSpeed = Stats.TurnScore;
        UpperController.TurnSpeed = Stats.TurretRotateScore;
    }
}
