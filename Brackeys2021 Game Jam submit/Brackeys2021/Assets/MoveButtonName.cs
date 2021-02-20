using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtonName : MonoBehaviour
{
    public int moveID;
    // Update is called once per frame
    void Update()
    {
        if ((GameObject.Find("Player").GetComponent<PlayerData>().PlayerMoves.Count - 1) >= moveID)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("Player").GetComponent<PlayerData>().PlayerMoves[moveID].GetComponent<Move>().moveData.moveName;
        }
        else
        {
            this.transform.Find("MoveName").GetComponent<UnityEngine.UI.Text>().text = "No move yet!";
        }
    }
}
