using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{

    void Update()
    {
        var PlayerHealthMax = (float)GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyMaxHealth;
        var PlayerHealthCurrent = (float)GameObject.Find("CurrentEnemy").GetComponent<CurrentEnemyData>().enemyCurrentHealth;
        this.GetComponent<UnityEngine.UI.Image>().fillAmount = PlayerHealthCurrent / PlayerHealthMax;
        Color healthy = new Color(0.00784f, 1f, 0.56f);
        Color damaged = new Color(1, 0.37647f, 0.45882f);
        Color critical = new Color(1f, 0, 0.56471f);
        Color chosen;

        if (PlayerHealthCurrent / PlayerHealthMax >= .5f)
        {
            chosen = healthy;
        }
        else if (PlayerHealthCurrent / PlayerHealthMax >= .25f)
        {
            chosen = damaged;
        }
        else
        {
            chosen = critical;
        }
        this.GetComponent<UnityEngine.UI.Image>().color = chosen;
    }
}
