using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handmedown : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1];
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1];
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
