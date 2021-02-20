using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnStatus : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Player").GetComponent<PlayerData>().playerTurnText)
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "YOUR TURN!";
        }
        else
        {
            this.GetComponent<UnityEngine.UI.Text>().text = "ENEMY TURN!";
        }
    }
}
