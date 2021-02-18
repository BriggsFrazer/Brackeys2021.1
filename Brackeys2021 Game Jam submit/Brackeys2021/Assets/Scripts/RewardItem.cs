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

    private void initData()
    {
        itemData = GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[PanelID].GetComponent<Item>().itemData;

        Debug.Log(itemData.name);

        this.gameObject.transform.Find("Card").gameObject.transform.Find("TitleText").GetComponent<UnityEngine.UI.Text>().text = (itemData.name);

        Debug.Log("Pressed!");
    }

    private void Start()
    {
        PanelID = 0;

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
