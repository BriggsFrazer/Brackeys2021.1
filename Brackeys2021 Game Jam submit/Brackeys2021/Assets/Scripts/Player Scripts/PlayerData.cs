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

    public GameObject tinySprites;

    public int currentStage;

    public int intendedDamage;

    public float timer;

    public float swapTime;

    public bool spriteToShow;
    public bool hit;


    public Sprite idle1;
    public Sprite idle2;
    public Sprite hitSprite;

    public GameEvent cardDataEvent;
    public void AddItem(int itemToAdd)
    {
        Debug.Log("Gettign item " + itemToAdd);
        if (this.GetComponent<ItemTracker>() != null)
        {
            Debug.Log("Has item tracker");
        }


        PlayerItems.Add(GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[itemToAdd]);

        Debug.Log("Item 1 " + GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[0].name);
        Debug.Log("Item 2 " + GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[1].name);
        Debug.Log("Item 3 " + GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[2].name);


        Debug.Log(GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[itemToAdd].name);
        Debug.Log(PlayerItems[PlayerItems.Count - 1].name);

        ItemEffect effect = (ItemEffect)GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[itemToAdd].GetComponent(typeof(ItemEffect));
        effect.AddEffect();
        
        if (GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[itemToAdd].GetComponent<Item>().itemData.wearable)
        {
            wearableSprite.GetComponent<Item>().itemData = GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[itemToAdd].GetComponent<Item>().itemData;

            Instantiate(wearableSprite, GameObject.Find("Player").transform, false);

        }


        UpdateItemImages();

        GameObject.Find("Player").GetComponent<ItemTracker>().ChooseNextThree();
    }

    public void UpdateItemImages()
    {
        var tinySpriteObjects = GameObject.FindGameObjectsWithTag("tinysprite");
        foreach(var item in tinySpriteObjects)
        {
            Destroy(item);
        }


        var counter = 0;
        foreach (var item in PlayerItems)
        {
            
            tinySprites.GetComponent<Item>().itemData = item.GetComponent<Item>().itemData;
            tinySprites.GetComponent<SpriteRenderer>().sprite = item.GetComponent<Item>().itemData.bigSprite;
            Instantiate(tinySprites, tinySprites.transform.position + new Vector3(0.15f*counter, 0), tinySprites.transform.rotation);
            counter += 1;
        }
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

        GameObject.Find("Canvas").transform.Find("RewardSelection").gameObject.SetActive(false);
    }

    public void Update()
    {
        if (hit)
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprite;
            for (int i = 0; i < this.transform.childCount; i++)
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
            for (int i = 0; i < this.transform.childCount; i++)
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
            for (int i = 0; i < this.transform.childCount; i++)
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
            GameObject.Find("Canvas").transform.Find("RewardSelection").gameObject.SetActive(true);
        }

        if (Input.GetKeyDown("d"))
        {
            this.GetComponent<ItemTracker>().PopulateAllItem();
        }
        if (Input.GetKeyDown("f"))
        {
            this.GetComponent<ItemTracker>().ChooseNextThree();
        }
        if (Input.GetKeyDown("g"))
        {
            cardDataEvent.Raise();
        }
    }
}

