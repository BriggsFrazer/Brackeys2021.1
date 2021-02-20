using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMoney : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = "MONEY: " +  GameObject.Find("Player").GetComponent<PlayerData>().Money.ToString();
    }
}
