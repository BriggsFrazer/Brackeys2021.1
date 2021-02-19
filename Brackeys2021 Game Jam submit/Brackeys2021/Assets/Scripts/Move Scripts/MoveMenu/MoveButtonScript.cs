using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonScript : MonoBehaviour
{
    public int moveID;


    public void Update()
    {

        if ((PlayerData.PlayerMoves.Count - 1) >= moveID)
        {
           this.transform.Find("MoveName").GetComponent<UnityEngine.UI.Text>().text = PlayerData.PlayerMoves[moveID].GetComponent<Move>().moveData.moveName;
            this.transform.Find("MoveName").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = PlayerData.PlayerMoves[moveID].GetComponent<Move>().moveData.description;
        }
        else
        {
            this.transform.Find("MoveName").GetComponent<UnityEngine.UI.Text>().text = "No move yet!";
            this.transform.Find("MoveName").transform.GetChild(0).GetComponent<UnityEngine.UI.Text>().text = "Click a move on both sides to see the cost to swap!";
        }
    }

    public void OnClick()
    {

        GameObject.Find("Cost").GetComponent<ShopCalculator>().playerItem = PlayerData.PlayerMoves[moveID];
        GameObject.Find("Cost").GetComponent<ShopCalculator>().playerItemNum = moveID;
    }
}
