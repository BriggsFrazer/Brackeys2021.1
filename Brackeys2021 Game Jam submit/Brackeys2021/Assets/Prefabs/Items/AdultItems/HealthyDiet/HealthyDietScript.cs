using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyDietScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        var counter = 0;
        for(int i = 0; i < GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers.Count; i++)
        {
            counter += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i];
        }

        GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth += counter;
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += counter;
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
