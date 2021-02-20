using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderdogStrikeScript : MonoBehaviour, MoveEffect
{
    public void UseEffect()
    {
        int damage = 0;
        damage += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] * 3;
        float Mod = 1 + (GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth / GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth);

        var damageFloat = damage * Mod;

        damage = (int) damageFloat;

        GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage = damage;
    }
}
