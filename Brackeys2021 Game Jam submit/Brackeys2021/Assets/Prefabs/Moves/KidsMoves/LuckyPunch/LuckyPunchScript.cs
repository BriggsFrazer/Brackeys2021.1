using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyPunchScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;
        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[0] * 2;

        Random.InitState(System.DateTime.Now.Millisecond);
        if(Random.Range(1,5) == 4)
        {
            damage *= 4;
        }

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}
