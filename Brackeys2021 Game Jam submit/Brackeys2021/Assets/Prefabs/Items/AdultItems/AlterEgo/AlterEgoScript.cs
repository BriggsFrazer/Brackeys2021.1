using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterEgoScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().Money += 30;


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
        AddEffect();

    }
}
