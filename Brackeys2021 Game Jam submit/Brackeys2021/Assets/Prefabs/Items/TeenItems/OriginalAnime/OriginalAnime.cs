using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalAnime : MonoBehaviour, ItemEffect
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

        GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[1] += 3;
        
    }
}
