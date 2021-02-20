using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaydayScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;

        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] * 6;

        if (GameObject.Find("Player").GetComponent<PlayerData>().Money > damage)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().Money -= damage/3;
        }
        else 
        {
            damage = 0;
        }

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}