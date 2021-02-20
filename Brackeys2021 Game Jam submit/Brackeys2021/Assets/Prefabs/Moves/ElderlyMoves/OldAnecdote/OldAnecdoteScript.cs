using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldAnecdoteScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;

        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] * 7;

        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] / 2;

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}
