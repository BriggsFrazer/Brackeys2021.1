using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEnemyData : MonoBehaviour
{
    public EnemyData enemyData;
    // Start is called before the first frame update

    public int enemyMaxHealth;
    public int enemyCurrentHealth;

    public int enemyDamage;

    public string enemyName;

    public bool spriteToShow;
    public bool hit;

    public float timer;

    public float swapTime;

    public Vector3 startPos;
    public Vector3 endPos;
    public Vector3 currentPos;

    void Update()
    {
        if (hit)
        {
            this.GetComponent<SpriteRenderer>().sprite = enemyData.HitSprite;
        }
        else if (spriteToShow)
        {
            this.GetComponent<SpriteRenderer>().sprite = enemyData.Idle1Sprite;
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = enemyData.Idle2Sprite;
        }

        timer += Time.deltaTime;
        if(timer > swapTime)
        {
            timer = 0;
            spriteToShow = !spriteToShow;
        }
    }

    public void InitialiseNewEnemy()
    {
        int currentStage = GameObject.Find("Player").GetComponent<PlayerData>().currentStage;

        enemyData = this.transform.GetChild(0).GetComponent<Enemy>().enemyData;
        enemyMaxHealth = enemyData.BaseHealth + (enemyData.BaseHealth/2 * currentStage);
        enemyName = enemyData.enemyName;
        enemyCurrentHealth = enemyMaxHealth;
        enemyDamage = enemyData.BaseDamage + (enemyData.BaseDamage * currentStage);
        

        this.GetComponent<SpriteRenderer>().sprite = enemyData.Idle1Sprite;
        GameObject.Find("Canvas").transform.Find("EnemyName").GetComponent<EnemyName>().UpdateText(enemyName);

    }

    public void AttackHero()
    {

        Random.InitState(System.DateTime.Now.Millisecond);
        var calcDamage = enemyDamage + Random.Range(-(enemyDamage/10),enemyDamage/10);

        StartCoroutine(GoForward());
        GameObject.Find("Player").GetComponent<PlayerData>().TakeDamge(calcDamage);
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

    public void GiveRewards()
    {
        GameObject.Find("Player").GetComponent<PlayerData>().Money += 50 + (GameObject.Find("Player").GetComponent<PlayerData>().currentStage * 50);
        List<int> demographicReward = new List<int>();

        int rewardAmount = 2;
        for (int i=0; i < GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers.Count; i++)
        {
            if (enemyData.demographicID == i+1)
            {
                GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i] += 5;
            }
            else {
                GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i] += rewardAmount;
            }
        }

    }
}
