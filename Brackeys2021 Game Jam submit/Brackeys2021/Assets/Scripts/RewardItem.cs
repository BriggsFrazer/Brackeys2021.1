using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class RewardItem : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    private GameEvent OnRewardSelected;


    private TMP_Text itemName;


    private Text description;


    private Image icon;


    private void initData()
    {
        //itemName.text = itemData.itemName;
        /*this.gameObject.transform.Find("Contents").gameObject.transform.Find("TitleText").GetComponent<TextMeshPro>().SetText(itemData.itemName);*/
       //Debug.Log(this.gameObject.name);
    }

    private void Start()
    {
        this.gameObject.transform.Find("Contents").gameObject.transform.Find("TitleText").GetComponent<TextMeshPro>().SetText(itemData.itemName);
        initData();
    }
    private void OnMouseDown()
    {
        initData();
        Debug.Log("Pressed!");
        OnRewardSelected.Raise();
    }

    private void DrawText()
    {

    }
}
