using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthNumbers : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        var PlayerHealthMax = (float)GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyMaxHealth;
        var PlayerHealthCurrent = (float)GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyCurrentHealth;

        this.GetComponent<UnityEngine.UI.Text>().text = (PlayerHealthCurrent + "/" + PlayerHealthMax);
    }
}
