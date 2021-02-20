using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeMachineScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3];
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3];


        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0];
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1];
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2];
        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] = 0;

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
