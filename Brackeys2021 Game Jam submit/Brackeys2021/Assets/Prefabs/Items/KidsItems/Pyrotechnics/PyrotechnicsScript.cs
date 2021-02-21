using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PyrotechnicsScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {



    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0];
    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
