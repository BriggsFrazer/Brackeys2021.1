using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject heartParticles;
    public GameObject thumbParticles;
    public GameObject sadParticles;



    // Start is called before the first frame update
    void Start()
    {
        InitScene();

    }


    void InitScene()
    {

        GameObject.Find("Canvas").transform.Find("RewardSelection").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("MoveMenu").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("EndScreenWin").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("EndScreenLose").gameObject.SetActive(false);

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

        if (GameObject.Find("Player").GetComponent<PlayerData>().currentStage >= 20)
        {
            GameObject.Find("Canvas").transform.Find("EndScreenWin").gameObject.SetActive(true);
        }

        GameObject.Find("Player").GetComponent<EnemyTracker>().ChooseNewEnemy();
        GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().InitialiseNewEnemy();

        GameObject.Find("Player").GetComponent<PlayerData>().DoEndOfTurn();


        GameObject.Find("Player").GetComponent<PlayerData>().PrevPlayerCurrentHealth = GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth;
        GameObject.Find("Player").GetComponent<PlayerData>().PrevPlayerMaxHealth = GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth;

        for (int i = 0; i <= GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers.Count - 1; i++)
        {
            GameObject.Find("Player").GetComponent<PlayerData>().PrevDemographicNumbers[i] = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i];
        }

        GameObject.Find("Player").GetComponent<PlayerData>().PrevMoney = GameObject.Find("Player").GetComponent<PlayerData>().Money;

    }

    public void NewTurnAnimations()
    {
        for (int i = 0; i < GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers.Count ; i++)
        {



            if (GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i] > GameObject.Find("Player").GetComponent<PlayerData>().PrevDemographicNumbers[i])
            {
                if (GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i] - GameObject.Find("Player").GetComponent<PlayerData>().PrevDemographicNumbers[i] >= 10)
                {
                    Instantiate(heartParticles, new Vector3(-0.45f + (0.3f * i), -0.394f, -1), sadParticles.transform.rotation);
                    Instantiate(thumbParticles, new Vector3(-0.45f + (0.3f * i), -0.394f, -1), sadParticles.transform.rotation);
                }
                else
                {
                    Instantiate(thumbParticles, new Vector3(-0.45f + (0.3f * i), -0.394f, -1), sadParticles.transform.rotation);
                }
            }
            if (GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i] < GameObject.Find("Player").GetComponent<PlayerData>().PrevDemographicNumbers[i])
            {
               Instantiate(sadParticles, new Vector3(-0.45f + (0.3f * i), -0.394f, -1), sadParticles.transform.rotation);
            }
        }
    }



    public void GoToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
