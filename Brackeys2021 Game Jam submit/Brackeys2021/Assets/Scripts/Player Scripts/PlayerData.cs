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

    public GameObject wearableSprite;

    public int currentStage;

    public int intendedDamage;

    public float timer;

    public float swapTime;

    public bool spriteToShow;
    public bool hit;


    public Sprite idle1;
    public Sprite idle2;
    public Sprite hitSprite;
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
        if (this.GetComponent<ItemTracker>().chosenItems[itemToAdd].GetComponent<ItemData>().wearable)
        {
            wearableSprite.GetComponent<Item>().itemData = this.GetComponent<ItemTracker>().chosenItems[itemToAdd].GetComponent<Item>().itemData;
            Instantiate(wearableSprite, this.transform);
        }

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

    public void Update()
    {
        if (hit)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite;
            for (int i = 0; i > this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).GetComponent<SpriteRenderer>())
                {
                    this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(i).GetComponent<Item>().itemData.hitSprite;
                }
            }
        }
        else if (spriteToShow)
        {
            this.GetComponent<SpriteRenderer>().sprite = idle1;
            for (int i = 0; i > this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).GetComponent<SpriteRenderer>())
                {
                    this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(i).GetComponent<Item>().itemData.idle1;
                }
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = idle2;
            for (int i = 0; i > this.transform.childCount; i++)
            {
                if (this.transform.GetChild(i).GetComponent<SpriteRenderer>())
                {
                    this.transform.GetChild(i).GetComponent<SpriteRenderer>().sprite = this.transform.GetChild(i).GetComponent<Item>().itemData.idle2;
                }
            }
        }

        timer += Time.deltaTime;
        if (timer > swapTime)
        {
            timer = 0;
            spriteToShow = !spriteToShow;
        }

        if (Input.GetKeyDown("a"))
        {
            GameObject.Find("Canvas").transform.Find("ItemPanel").gameObject.SetActive(true);
        }
    }
}

