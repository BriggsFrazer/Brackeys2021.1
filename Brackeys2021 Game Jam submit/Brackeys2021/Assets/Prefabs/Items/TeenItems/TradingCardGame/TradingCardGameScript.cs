using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingCardGameScript : MonoBehaviour, ItemEffect
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
        Random.InitState(System.DateTime.Now.Millisecond);
        if (Random.Range(1, 5) == 4)
        {

            GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] += 10;
        }
    }
}
