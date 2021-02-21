using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildrensBlockGameScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] += 3;

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] += 3;
    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
