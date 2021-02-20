using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbsorbYouthScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;
        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] * 2;

        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += damage;

        if(GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth > GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth = GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth;
        }

        if (GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] > 0)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[2] += 1;
            GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[3] -= 1;
        }



        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}
