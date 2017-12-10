﻿using System;
using UnityEngine;

public class PlayerLoader :MonoBehaviour
{
    public Loadout[] DefaultLoadouts;
    public Transform[] SpawnPoints;

    private PlayerResources resources;

    void Start()
    {
        resources = this.GetComponent<PlayerResources>();
        Load();
    }

    public void Load()
    {
        LoadDefault();
    }

    void LoadDefault()
    {
        int playerIndex = 0;
        foreach (var ldt in DefaultLoadouts)
        {
            var bot = Instantiate(resources.GetBot(ldt.Country), SpawnPoints[playerIndex].position, Quaternion.identity).GetComponent<PlayerBot>();
            bot.LoadPrimary(resources.GetPrimary(ldt.PrimaryWeapon));
            bot.LoadSecondary(resources.GetSecondary(ldt.SecondaryWeapon));
            bot.PlayerId = playerIndex + 1;

            playerIndex++;
        }
    }
}
