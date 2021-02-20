using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public List<GameObject> allEnemies;
    public GameObject currentEnemy;
    public GameObject enemyHolder;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < enemyHolder.transform.childCount; i++)
        {
            allEnemies.Add(enemyHolder.transform.GetChild(i).gameObject);
        }

        allEnemies[0].transform.parent = currentEnemy.transform;
        currentEnemy.GetComponent<CurrentEnemyData>().InitialiseNewEnemy();
        ChooseNewEnemy();

    }




    public void ChooseNewEnemy()
    {

       currentEnemy.transform.GetChild(0).parent = enemyHolder.transform;

       //Gets the enemy that was just readded and orders it by its ID in the child hierarchy
       enemyHolder.transform.GetChild(enemyHolder.transform.childCount-1).SetSiblingIndex(enemyHolder.transform.GetChild(enemyHolder.transform.childCount-1).GetComponent<Enemy>().enemyData.enemyID);


       int id = Random.Range(0, allEnemies.Count);
       foreach (var enemy in allEnemies)
        {
            var enemyData = enemy.GetComponent<Enemy>().enemyData.enemyID;
            if (enemyData == id)
            {
                allEnemies[id].transform.parent = currentEnemy.transform;
                currentEnemy.GetComponent<CurrentEnemyData>().InitialiseNewEnemy();

            }
        }
    }
}
