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
    [SerializeField]
    private GameEvent OnRewardSelected2;
    [SerializeField]
    private GameEvent OnRewardSelected3;

    public GameEvent ItemChosen;

    private Text itemName;


    private Text description;


    private Image icon;

    public int PanelID;

    private Color[] colors = { Color.white, new Color(0.1725f, 1, 0.98f), new Color(0.227f, 1, 0.6f), new Color(1, 0.741f, 0), new Color(1, 0.584f, 0.871f),  Color.green }; 

    public void OnEnable()
    {
        if (PanelID < GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems.Count)
        {
            itemData = GameObject.Find("Player").GetComponent<ItemTracker>().chosenItems[PanelID].GetComponent<Item>().itemData;



            this.gameObject.transform.Find("Card").gameObject.transform.Find("TitleText").GetComponent<UnityEngine.UI.Text>().text = (itemData.itemName);

            this.gameObject.transform.Find("Card").gameObject.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().sprite = (itemData.bigSprite);

            this.gameObject.transform.Find("Card").gameObject.transform.Find("Border").GetComponent<UnityEngine.UI.Image>().color = colors[itemData.demographicID];

            this.gameObject.transform.Find("Card").gameObject.transform.Find("Description").GetComponent<UnityEngine.UI.Text>().text = itemData.description;

        }
    }

    private void Start()
    {        
    }

    public void OnClick()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        // initData();
        if (PanelID == 0)
        {
            OnRewardSelected1.Raise();
        }
        else if (PanelID == 1)
        {
            OnRewardSelected2.Raise();
        }
        else
        {
            OnRewardSelected3.Raise();
        }
       this.transform.parent.gameObject.SetActive(false);
        ItemChosen.Raise();
    }


}
