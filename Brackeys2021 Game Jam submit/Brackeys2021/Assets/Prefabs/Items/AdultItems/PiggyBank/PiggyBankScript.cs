using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyBankScript : MonoBehaviour, ItemEffect
{
    public void AddEffect()
    {
        if (GameObject.Find("Player").GetComponent<PlayerData>().Money >= 10)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().Money -= 10;
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
        if (GameObject.Find("Player").GetComponent<PlayerData>().Money > 10)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().Money -= 10;
        }
        if (GameObject.Find("Player").GetComponent<PlayerData>().currentStage%5 == 0)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().Money += 10;
        }
    }
}
