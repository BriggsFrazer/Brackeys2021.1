using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InheritanceScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {

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
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] += (int)GameObject.Find("Player").GetComponent<PlayerData>().Money / 100;
    }
}
