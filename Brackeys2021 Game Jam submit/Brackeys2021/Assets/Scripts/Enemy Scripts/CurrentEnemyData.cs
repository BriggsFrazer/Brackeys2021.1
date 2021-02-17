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



    void Start()
    {
        
    }

    public void InitialiseNewEnemy()
    {
        int currentStage = GameObject.Find("Player").GetComponent<PlayerData>().currentStage;

        enemyData = this.transform.GetChild(0).GetComponent<Enemy>().enemyData;
        enemyMaxHealth = enemyData.BaseHealth + (enemyData.BaseHealth * currentStage);
        enemyCurrentHealth = enemyMaxHealth;
        enemyDamage = enemyData.BaseDamage + (enemyData.BaseDamage * currentStage);

        this.GetComponent<SpriteRenderer>().sprite = enemyData.Idle1Sprite;

    }



}
