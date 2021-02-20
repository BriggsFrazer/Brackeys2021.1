using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DadJokeScript : MonoBehaviour, MoveEffect
{

    public void UseEffect()
    {
        int damage = 0;

        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] * 7;

        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] / 2;

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}
