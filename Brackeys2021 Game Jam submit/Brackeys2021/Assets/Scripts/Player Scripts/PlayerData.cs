﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static List<GameObject> PlayerItems = new List<GameObject>();
    public List<GameObject> PlayerMoves;

    public GameObject startingMove;

    public int PrevPlayerMaxHealth;
    public int PlayerMaxHealth;

    public int PrevPlayerCurrentHealth;
    public int PlayerCurrentHealth;

    public List<int> DemographicMultipliers;
    public List<int> PrevDemographicNumbers;
    public List<int> DemographicNumbers;

    public int PrevMoney;
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


    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 currentPos;
    public void AddItem(int itemToAdd)
    {


        PlayerItems.Add(GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[itemToAdd]);



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
        Debug.Log("Called to do move" + moveId);
        MoveEffect effect = (MoveEffect)GameObject.Find("Player").GetComponent<PlayerData>().PlayerMoves[moveId].GetComponent(typeof(MoveEffect));
        effect.UseEffect();

        DealDamage();
        playerTurn = false;
        StartCoroutine(HitEnemy());
    }

    public void DoEndOfTurn()
    {

        for (int i = 0; i < PlayerItems.Count; i++)
        {

            ItemEffect effect = (ItemEffect)PlayerItems[i].GetComponent(typeof(ItemEffect));
            effect.PassiveTurnEffect();
        }
    }





    IEnumerator HitEnemy()
    {
        GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().hit = true;
        yield return new WaitForSeconds(1);
        if (GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyCurrentHealth <= 0)
        {
            GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().GiveRewards();
            GameObject.Find("GameController").GetComponent<GameController>().DisplayRewards();
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
        StartCoroutine(GoForward());

        GameObject.Find("CurrentEnemy").GetComponent<AudioSource>().Play();
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



        GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth -= intendedIncomingDamage;

        if (PlayerCurrentHealth <= 0)
        {
            GameObject.Find("Canvas").transform.Find("EndScreenLose").gameObject.SetActive(true);
        }
    }

    IEnumerator IsHit()
    {
        gameObject.GetComponent<AudioSource>().Play();
        hit = true;
        yield return new WaitForSeconds(1);
        hit = false;
    }

    public void Start()
    {
        DemographicNumbers = new List<int> { 5, 5, 5, 5 };
        PrevDemographicNumbers = new List<int> { 5,5,5,5};

        DemographicMultipliers = new List<int> { 1, 1, 1, 1 };
     
        Money = 0;
        PrevMoney = Money;

        PrevPlayerCurrentHealth = PlayerCurrentHealth;
        PrevPlayerMaxHealth = PlayerMaxHealth;

        playerTurn = true;
        playerTurnText = true;
        currentStage = 0;

        PlayerItems.Clear();

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

    IEnumerator GoForward()
    {
        float elapsedTime = 0;
        float waitTime = 0.2f;
        currentPos = transform.position;
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, endPos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = endPos;
        StartCoroutine(GoBack());
        yield return null;
    }
    IEnumerator GoBack()
    {
        float elapsedTime = 0;
        float waitTime = 0.2f;
        currentPos = transform.position;
        while (elapsedTime < waitTime)
        {
            transform.position = Vector3.Lerp(currentPos, startPos, (elapsedTime / waitTime));
            elapsedTime += Time.deltaTime;

            yield return null;
        }
        transform.position = startPos;
        yield return null;
    }
}

