using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopMove : MonoBehaviour
{



    public GameObject moveData;


    public int moveID;

    public void OnEnable()
    {

        if (GameObject.Find("Player").GetComponent<MoveTracker>().currentMoves.Count > moveID)
        {

           moveData = GameObject.Find("Player").GetComponent<MoveTracker>().currentMoves[moveID];

           this.gameObject.transform.Find("Button").gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = (moveData.GetComponent<Move>().moveData.moveName);

           this.gameObject.transform.Find("Image").gameObject.transform.Find("Text").GetComponent<UnityEngine.UI.Text>().text = (moveData.GetComponent<Move>().moveData.description);

        }

    }

    public void OnShopClick()
    {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();

        if (GameObject.Find("Player").GetComponent<MoveTracker>().currentMoves.Count > moveID) { 
            GameObject.Find("Cost").GetComponent<ShopCalculator>().shopItem = GameObject.Find("Player").GetComponent<MoveTracker>().currentMoves[moveID];
            GameObject.Find("Cost").GetComponent<ShopCalculator>().shopItemNum = moveID;
         }

    }



}
