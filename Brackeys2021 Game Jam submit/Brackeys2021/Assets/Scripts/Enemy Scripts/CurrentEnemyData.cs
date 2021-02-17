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


    void Start()
    {
        
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



}
