using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {

        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += 100;

        if (GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth > GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth = GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth;
        }

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {



    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
