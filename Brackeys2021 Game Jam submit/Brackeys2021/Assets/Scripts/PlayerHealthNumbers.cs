using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthNumbers : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        var PlayerHealthMax = (float)GameObject.Find("Player").GetComponent<PlayerData>().PlayerMaxHealth;
        var PlayerHealthCurrent = (float)GameObject.Find("Player").GetComponent<PlayerData>().PlayerCurrentHealth;

        this.GetComponent<UnityEngine.UI.Text>().text = (PlayerHealthCurrent + "/" + PlayerHealthMax);
    }
}
