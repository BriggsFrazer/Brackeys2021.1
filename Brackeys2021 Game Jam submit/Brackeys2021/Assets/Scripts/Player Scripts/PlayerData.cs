using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static List<GameObject> PlayerItems = new List<GameObject>();
    public static List<GameObject> PlayerMoves = new List<GameObject>();

    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;

    public List<int> DemographicMultipliers;
    public List<int> DemographicNumbers;
    public int Money;

    public int currentStage;

    public int intendedDamage;

    public void AddItem(int itemToAdd)
    {
        Debug.Log(this);
        if (this.GetComponent<ItemTracker>() != null)
        {
            Debug.Log("Has item tracker");
        }

        PlayerItems.Add(this.GetComponent<ItemTracker>().chosenItems[itemToAdd]);
        ItemEffect effect = (ItemEffect)this.GetComponent<ItemTracker>().chosenItems[itemToAdd].GetComponent(typeof(ItemEffect));
        effect.AddEffect();

        this.GetComponent<ItemTracker>().ChooseNextThree();
        Debug.Log(PlayerItems.Count);
    }

    public void DoMove(int moveId)
    {

        MoveEffect effect = (MoveEffect)this.GetComponent<MoveTracker>().currentMoves[moveId].GetComponent(typeof(MoveEffect));
        effect.UseEffect();

        DealDamage();
 
    }


    public void DealDamage()
    {
        Debug.Log(PlayerItems.Count);
        for (int i = 0; i < PlayerItems.Count; i++) {
            
            ItemEffect effect = (ItemEffect)PlayerItems[i].GetComponent(typeof(ItemEffect));
            effect.PassiveCombatEffect();
        }

        GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyCurrentHealth -= intendedDamage;
    }

    public void Start()
    {
        DemographicNumbers = new List<int> { 5, 5, 5, 5 };
        DemographicMultipliers = new List<int> { 1, 1, 1, 1 };
        Money = 0;

    }

}

