using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "YOU HAVE BEEN DEFEATED! \n YOU HAVE REACHED ROUND: " + GameObject.Find("Player").GetComponent<PlayerData>().currentStage + "\n BACK TO MENU";
    }
}
