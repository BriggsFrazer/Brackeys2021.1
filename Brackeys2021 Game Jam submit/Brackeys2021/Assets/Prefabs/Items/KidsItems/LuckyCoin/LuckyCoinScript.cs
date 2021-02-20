using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCoinScript : MonoBehaviour, ItemEffect
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
        if (Random.Range(1, 3) == 2)
        {
            
            for (int i = 0; i < GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers.Count; i++)
            {
                GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i] += 1;
            }
        }
        else
        {
            GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth += 10;
            GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth += 10;
        }
    }
}
