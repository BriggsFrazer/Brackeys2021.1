using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyName : MonoBehaviour
{
    public void UpdateText(string name)
    {
       this.GetComponent<UnityEngine.UI.Text>().text = name;
    }
}
