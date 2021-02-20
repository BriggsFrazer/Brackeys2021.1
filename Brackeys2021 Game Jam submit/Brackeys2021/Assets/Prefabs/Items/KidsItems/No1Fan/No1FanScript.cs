using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No1FanScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] += 1;

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage += 5;

    }

    public void PassiveOnDefendEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().intendedIncomingDamage -= 5;
    }

    public void PassiveTurnEffect()
    {

    }
}
