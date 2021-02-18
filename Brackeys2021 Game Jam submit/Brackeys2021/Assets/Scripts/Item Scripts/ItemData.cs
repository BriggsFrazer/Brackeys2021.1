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
    public Sprite idle1;

    [SerializeField]
    public Sprite idle2;

    [SerializeField]
    public Sprite hitSprite;


    [SerializeField]
    public bool wearable;

    [SerializeField]
    public int id;

    [SerializeField]
    public int demographicID;

}

