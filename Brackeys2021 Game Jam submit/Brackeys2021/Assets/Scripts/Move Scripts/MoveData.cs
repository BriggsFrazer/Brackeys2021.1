using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New MoveData", menuName = "Move Data", order = 53)]
public class MoveData : ScriptableObject
{

    [SerializeField]
    public string moveName;


    [SerializeField]
    public string description;


    [SerializeField]
    public int cost;


    [SerializeField]
    public int id;

    [SerializeField]
    public int demographicId;

}
