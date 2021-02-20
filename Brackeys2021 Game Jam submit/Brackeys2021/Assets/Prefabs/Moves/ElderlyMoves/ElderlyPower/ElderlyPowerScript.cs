using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElderlyPowerScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;
        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] * 5;

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}

