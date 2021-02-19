using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TVShowScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        Debug.Log("TV Show used");
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] += 10;
    }

    public void RemoveEffect()
    {

    }

    public void PassiveCombatEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
