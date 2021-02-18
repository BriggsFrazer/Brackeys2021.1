using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class RewardItem : MonoBehaviour
{
    private ItemData itemData;

    [SerializeField]
    private GameEvent OnRewardSelected1;
    private GameEvent OnRewardSelected2;
    private GameEvent OnRewardSelected3;


    private Text itemName;


    private Text description;


    private Image icon;

    public int PanelID;

    private Color[] colors = { new Color(0.1725f, 1, 0.98f), new Color(0.227f, 1, 0.6f), new Color(1, 0.741f, 0), new Color(1, 0.584f, 0.871f),  Color.green }; 

    private void initData()
    {
        itemData = GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[PanelID].GetComponent<Item>().itemData;

        

        this.gameObject.transform.Find("Card").gameObject.transform.Find("TitleText").GetComponent<UnityEngine.UI.Text>().text = (itemData.itemName);
        
        this.gameObject.transform.Find("Card").gameObject.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().sprite = (itemData.bigSprite);
        
        this.gameObject.transform.Find("Card").gameObject.transform.Find("Border").GetComponent<UnityEngine.UI.Image>().color = colors[itemData.demographicID];

        this.gameObject.transform.Find("Card").gameObject.transform.Find("Description").GetComponent<UnityEngine.UI.Text>().text = itemData.description;

        Debug.Log("Pressed!");
    }

    private void OnStart()
    {
        PanelID = 0;
        initData();
    }
    public void OnClick()
    {
        initData();

        OnRewardSelected1.Raise();
    }

    private void DrawText()
    {

    }
}
