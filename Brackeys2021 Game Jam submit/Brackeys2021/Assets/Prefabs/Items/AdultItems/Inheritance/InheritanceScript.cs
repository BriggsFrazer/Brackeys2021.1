using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        var count = (int)GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3]/2;
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] = count;
        GameObject.Find("Player").GetComponent<PlayerData>().Money += count*50;

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
