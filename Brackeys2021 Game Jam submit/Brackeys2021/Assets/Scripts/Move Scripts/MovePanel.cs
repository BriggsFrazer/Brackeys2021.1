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

        
    }

    private void Start()
    {

        
    }

    private void OnMouseDown()
    {
        if (GameObject.Find("Player").GetComponent<PlayerData>().playerTurn)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 0.8235f, 0.9654f);
            move1Selected.Raise();
        }
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
