using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanPowerEffect : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;
        foreach (var demographic in GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers)
        {
            damage += demographic;
        }


       GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }

}
