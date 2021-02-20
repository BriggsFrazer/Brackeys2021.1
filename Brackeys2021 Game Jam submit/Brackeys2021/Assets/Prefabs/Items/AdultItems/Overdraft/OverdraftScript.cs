using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverdraftScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {
        if (GameObject.Find("Player").GetComponent<PlayerData>().Money >= 20)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().Money -= 20;
            GameObject.Find("Player").GetComponent<PlayerData>().intendedDamage += 20;
        }
    }

    public void PassiveOnDefendEffect()
    {

    }

    public void PassiveTurnEffect()
    {

    }
}
