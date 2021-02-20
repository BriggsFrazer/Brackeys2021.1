using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        if (GameObject.Find("Player").GetComponent<PlayerData>().Money >= 1)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().Money -= 1;
            GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] += 1;
        }

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
        if (GameObject.Find("Player").GetComponent<PlayerData>().Money >= 1)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().Money -= 1;
            GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] += 1;
        }

    }
}
