using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    [SerializeField]
    public string enemyName;


    [SerializeField]
    public Sprite Idle1Sprite;


    [SerializeField]
    public Sprite Idle2Sprite;


    [SerializeField]
    public Sprite HitSprite;

    [SerializeField]
    public int  BaseDamage;

    [SerializeField]
    public int BaseHealth;

    [SerializeField]
    public int enemyID;

    [SerializeField]
    public int demographicID;

}
