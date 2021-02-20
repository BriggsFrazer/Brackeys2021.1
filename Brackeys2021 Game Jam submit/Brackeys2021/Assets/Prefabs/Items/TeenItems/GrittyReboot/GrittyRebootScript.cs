using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrittyRebootScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] += 5;

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1];
    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
