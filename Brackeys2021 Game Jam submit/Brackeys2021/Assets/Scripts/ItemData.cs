using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New ItemData", menuName = "Item Data", order = 51)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    public string itemName;


    [SerializeField]
    public string description;


    [SerializeField]
    public Sprite bigSprite;


    [SerializeField]
    public Sprite littleSprite;


    [SerializeField]
    public bool wearable;



}

