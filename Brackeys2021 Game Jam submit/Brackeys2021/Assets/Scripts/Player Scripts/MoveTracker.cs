using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTracker : MonoBehaviour
{
    public List<GameObject> allMoves;
    public GameObject moveHolder;
    public List<GameObject> currentMoves;


    void Start()
    {

        for (int i = 0; i < moveHolder.transform.childCount; i++)
        {
            allMoves.Add(moveHolder.transform.GetChild(i).gameObject);
        }

        
        currentMoves.Add(allMoves[0]);
        Debug.Log(allMoves.Count);

    }

}
