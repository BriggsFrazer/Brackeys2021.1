using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidekickScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {

       GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] += 1;


    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage += GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage/10;

    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
