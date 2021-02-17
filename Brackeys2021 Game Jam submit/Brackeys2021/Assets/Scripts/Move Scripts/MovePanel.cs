using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePanel: MonoBehaviour
{
    public int panelID;
    public MoveData moveData;

    [SerializeField]
    private GameEvent move1Selected;



    private void initData()
    {
        //moveData = GameObject.Find("Player").GetComponent<MoveTracker>().currentMoves[panelID];

        //this.gameObject.transform.Find("Contents").gameObject.transform.Find("TitleText").GetComponent<TextMeshPro>().SetText(itemData.name);

        
    }

    private void Start()
    {
        panelID = 0;
        
    }

    private void OnMouseDown()
    {
        initData();
        Debug.Log("Pressed!");
        move1Selected.Raise();

    }

    // Update is called once per frame
    
}
