using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static List<GameObject> PlayerItems = new List<GameObject>();
    public static List<GameObject> PlayerMoves = new List<GameObject>();

    public GameObject startingMove;

    public int PlayerMaxHealth;
    public int PlayerCurrentHealth;

    public List<int> DemographicMultipliers;
    public List<int> DemographicNumbers;
    public int Money;

    public GameObject wearableSprite;

    public GameObject tinySprites;

    public int currentStage;

    public int intendedDamage;
    public int intendedIncomingDamage;

    public float timer;

    public float swapTime;

    public bool spriteToShow;
    public bool hit;
    public bool playerTurn;
    public bool playerTurnText;

    public Sprite idle1;
    public Sprite idle2;
    public Sprite hitSprite;

    public GameEvent cardDataEvent;
    public void AddItem(int itemToAdd)
    {


        PlayerItems.Add(GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[itemToAdd]);

        Debug.Log("Item 1 " + GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[0].name);
        Debug.Log("Item 2 " + GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[1].name);
        Debug.Log("Item 3 " + GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[2].name);




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

        MoveEffect effect = (MoveEffect)PlayerData.PlayerMoves[moveId].GetComponent(typeof(MoveEffect));
        effect.UseEffect();

        DealDamage();
        playerTurn = false;
        StartCoroutine(HitEnemy());
    }

    IEnumerator HitEnemy()
    {
        GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().hit = true;
        yield return new WaitForSeconds(1);
        if (GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyCurrentHealth <= 0)
        {
            GameObject.Find("GameController").GetComponent<GameController>().DisplayRewards();
            StartCoroutine(GameObject.Find("GameController").GetComponent<GameController>().SwapPlayerTurn());
            GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().hit = false;
        }
        else
        {
            GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().hit = false;
            playerTurnText = false;

            GameObject.Find("GameController").GetComponent<GameController>().EnemyTurn();
        }
    }

    public void DealDamage()
    {
        Debug.Log(PlayerItems.Count);
        for (int i = 0; i < PlayerItems.Count; i++) {
            
            ItemEffect effect = (ItemEffect)PlayerItems[i].GetComponent(typeof(ItemEffect));
            effect.PassiveOnAttackEffect();
        }

        GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyCurrentHealth -= intendedDamage;
    }

    public void TakeDamge(int intended)
    {
        intendedIncomingDamage = intended;
        Debug.Log(PlayerItems.Count);
        for (int i = 0; i < PlayerItems.Count; i++)
        {

            ItemEffect effect = (ItemEffect)PlayerItems[i].GetComponent(typeof(ItemEffect));
            effect.PassiveOnDefendEffect();
        }

        if(intendedIncomingDamage < 0)
        {
            intendedIncomingDamage = 0;
        }
        else
        {
            StartCoroutine(IsHit());
        }

        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth -= intendedDamage;
    }

    IEnumerator IsHit()
    {
        hit = true;
        yield return new WaitForSeconds(1);
        hit = false;
    }

    public void Start()
    {
        DemographicNumbers = new List<int> { 5, 5, 5, 5 };
        DemographicMultipliers = new List<int> { 1, 1, 1, 1 };
        Money = 0;
        playerTurn = true;
        playerTurnText = true;
        currentStage = 0;

        PlayerMoves.Add(startingMove);
        PlayerMoves.Add(startingMove);
        PlayerMoves.Add(startingMove);



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


    }
}

