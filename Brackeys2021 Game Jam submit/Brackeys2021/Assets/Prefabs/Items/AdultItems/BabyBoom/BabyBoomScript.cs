﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBoomScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2]/2;

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

    }
}
