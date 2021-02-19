using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemographicNum : MonoBehaviour
{
    public int id;

    private Color[] colors = {new Color(0.1725f, 1, 0.98f), new Color(0.227f, 1, 0.6f), new Color(1, 0.741f, 0), new Color(1, 0.584f, 0.871f), Color.green };
    // Update is called once per frame
    void Update()
    {
        this.GetComponent<UnityEngine.UI.Text>().text = GameObject.Find("Player").GetComponent<PlayerData>().DemographicNumbers[id].ToString();
        this.GetComponent<UnityEngine.UI.Text>().color = colors[id];
    }
}
