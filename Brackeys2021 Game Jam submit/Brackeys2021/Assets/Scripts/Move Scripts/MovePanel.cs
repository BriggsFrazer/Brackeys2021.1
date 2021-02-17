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
        this.GetComponent<SpriteRenderer>().color = Color.red;
        move1Selected.Raise();

    }
    private void OnMouseUp()
    {
        this.GetComponent<SpriteRenderer>().color = Color.white;
    }


    private void OnMouseOver()
    {
        this.transform.localScale = new Vector3(1.1f, 1.1f);
    }

    private void OnMouseExit()
    {
        this.transform.localScale = new Vector3(1f, 1f);
    }
    // Update is called once per frame

}
