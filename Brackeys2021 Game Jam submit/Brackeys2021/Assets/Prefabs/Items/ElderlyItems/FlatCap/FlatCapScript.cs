using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatCapScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {

    }

    public void RemoveEffect()
    {

    }

    public void PassiveOnAttackEffect()
    {

    }

    public void PassiveOnDefendEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().intendedIncomingDamage -= 10;
    }

    public void PassiveTurnEffect()
    {

    }
}
