using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBlastScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;

        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] * 7;

        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] / 2;

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}
