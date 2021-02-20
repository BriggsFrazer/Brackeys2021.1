using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFans : MonoBehaviour
{

    

    void Update()
    {
        int fancount = 0;
        for(int i = 0; i < GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers.Count; i++)
        {
            fancount += GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[i];
        }
        this.GetComponent<UnityEngine.UI.Text>().text = "Total Fans: " + fancount;
    }
}
