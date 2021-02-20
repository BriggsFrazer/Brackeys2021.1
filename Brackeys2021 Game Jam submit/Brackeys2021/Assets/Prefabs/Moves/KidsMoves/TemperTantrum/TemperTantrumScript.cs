using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemperTantrumScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;

        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] * 7;

        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] / 2;

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}
