using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunglassesScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {

        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] += 15;
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
