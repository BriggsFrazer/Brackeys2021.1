using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTracker : MonoBehaviour
{
    public List<GameObject> allMoves;
    public GameObject moveHolder;
    public GameObject defaultMove;
    public List<GameObject> currentMoves;

    public int moveCount;

    void Start()
    {

    }


    public void PopulateMoves()
    {
        for (int i = 0; i < GameObject.Find("MoveHolder").transform.childCount; i++)
        {
            Debug.Log("Added move: " + i);
            allMoves.Add(GameObject.Find("MoveHolder").transform.GetChild(i).gameObject);
        }

        moveCount = GameObject.Find("MoveHolder").transform.childCount;

    }

    public void ChooseNextThree()
    {
       currentMoves.Clear();


        Random.InitState(System.DateTime.Now.Millisecond);

        for (int i = 0; i < 3; i++)
        {
            int id = Random.Range(0, moveCount);
            Debug.Log(id + " chosen id");

            foreach (var move in allMoves)
            {
                var MoveData = move.GetComponent<Move>().moveData.id;
                if (MoveData == id)
                {
                    currentMoves.Add(move);

                }
            }


        }


    }
}


