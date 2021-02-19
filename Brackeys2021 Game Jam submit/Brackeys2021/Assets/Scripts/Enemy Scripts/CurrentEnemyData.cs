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
        enemyMaxHealth = enemyData.BaseHealth + (enemyData.BaseHealth * currentStage);
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


        GameObject.Find("Player").GetComponent<PlayerData>().TakeDamge(calcDamage);
    }


}
