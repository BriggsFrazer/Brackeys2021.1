using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCalculator : MonoBehaviour
{

    public GameObject playerItem;
    public int playerItemNum;
    public GameObject shopItem;
    public int shopItemNum;

    public int cost;
    // Update is called once per frame
    void Update()
    {
        if(playerItem && shopItem)
        {
            
            cost = shopItem.GetComponent<Move>().moveData.cost;
           
        }
        else
        {
            cost = 0;
        }
        this.transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Cost: " + cost.ToString();
    }

    public void SwapItems(int i)
    {
        if(i == 1)
        {
            ResetShop();
            this.transform.parent.gameObject.SetActive(false);
        }

        if (playerItem && shopItem)
        {
            if (GameObject.Find("Player").GetComponent<PlayerData>().Money >= cost)
            {
                GameObject.Find("Player").GetComponent<PlayerData>().Money -= cost;
                GameObject.Find("Player").GetComponent<PlayerData>().PlayerMoves[playerItemNum] = shopItem;
                GameObject.Find("Player").GetComponent<MoveTracker>().currentMoves[shopItemNum] = playerItem;
            }
            ResetShop();
        }
        this.transform.parent.gameObject.SetActive(false);
    }

    public void ResetShop()
    {
        playerItem = null;
        shopItem = null;
    }
}
