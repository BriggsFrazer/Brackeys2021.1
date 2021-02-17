using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaCookieScript : MonoBehaviour, ItemEffect
{ 
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth += 50;
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += 50;
    }

    public void RemoveEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth -= 50;
    }

    public void PassiveCombatEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
