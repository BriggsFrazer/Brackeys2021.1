using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaydayScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;
        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] * 2;

        GameObject.Find("Player").GetComponent<PlayerData>().Money += damage;

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}