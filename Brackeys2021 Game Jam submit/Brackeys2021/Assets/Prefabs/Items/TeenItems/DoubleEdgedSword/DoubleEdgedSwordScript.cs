using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleEdgedSwordScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] += 1;

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {
        if (GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] > 1)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] -= 1;
            GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage += 20;
        }
    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
