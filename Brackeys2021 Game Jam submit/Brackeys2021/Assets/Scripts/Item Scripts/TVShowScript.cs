using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVShowScript : MonoBehaviour, ItemEffect
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

    }

    public void PassiveOnDefendEffect()
    {

    }
    public void PassiveTurnEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] += 3;
    }
}
