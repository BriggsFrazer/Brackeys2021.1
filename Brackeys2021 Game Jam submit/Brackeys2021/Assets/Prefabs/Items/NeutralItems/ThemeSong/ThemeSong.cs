﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeSong : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        PassiveTurnEffect();

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {



    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {
        for (int i = 0; i < GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers.Count; i++)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i] += 2;
        }
    }
}
