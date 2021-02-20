using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuppyScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        PassiveTurnEffect();

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

        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth/10;
        if(GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth > GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth = GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth;
        }
        
    }
}
