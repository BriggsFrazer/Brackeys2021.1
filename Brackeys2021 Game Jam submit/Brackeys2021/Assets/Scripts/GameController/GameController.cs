using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{


    /* GAME FLOW
    1)Fight Scene loads
    -- Take note of start health, start demographic, start gold
    2)Click on move
    3)Calculate damage (move effect + passive items)
    4)Deal Damage
    5)Check if dead 
    6)Enemy turn
    7)Calculate enemy damage (passive items check)
    8)Deal Damage
    9)Check if dead
    10)Go back to 2

    11) End of combat, add to counters, reveal menu options if applicable
    12) Show items reward
    13) Show move shop
    14) Start + compare current stats with old start turn stats
    15) if demographic up -> show effect
    16) item passive effects
    17) Go back to 2
     
     */






    // Start is called before the first frame update
    void Start()
    {
        InitScene();

    }


    void InitScene()
    {

        GameObject.Find("Canvas").transform.Find("RewardSelection").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("MoveMenu").gameObject.SetActive(false);
        GameObject.Find("Player").GetComponent<ItemTracker>().PopulateAllItem();
        GameObject.Find("Player").GetComponent<MoveTracker>().PopulateMoves();
        GameObject.Find("Player").GetComponent<MoveTracker>().ChooseNextThree();
    }

    public void EnemyTurn()
    {

        StartCoroutine(EnemyDoAttack());
        StartCoroutine(SwapPlayerTurn());
        
    }

    public IEnumerator SwapPlayerTurn()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Find("Player").GetComponent<PlayerData>().playerTurn = true;
        GameObject.Find("Player").GetComponent<PlayerData>().playerTurnText = true;
        
    }

    IEnumerator EnemyDoAttack()
    {
        yield return new WaitForSeconds(1f);
        GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().AttackHero();
    }

    public void DisplayRewards()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().currentStage += 1;
        GameObject.Find("Player").GetComponent<ItemTracker>().ChooseNextThree();
        GameObject.Find("Canvas").transform.Find("RewardSelection").gameObject.SetActive(true);
        if (GameObject.Find("Player").GetComponent<PlayerData>().currentStage % 3 == 0)
        {
            DisplayShop();
        }
        StartNewTurn();
    }

    void DisplayShop()
    {

        GameObject.Find("Player").GetComponent<MoveTracker>().ChooseNextThree();
        GameObject.Find("Canvas").transform.Find("MoveMenu").gameObject.SetActive(true);

    }

    void StartNewTurn()
    {
        GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().InitialiseNewEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
