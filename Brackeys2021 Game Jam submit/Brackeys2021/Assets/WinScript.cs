using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<UnityEngine.UI.Text>().text = "CONGRATULATIONS YOU HAVE WON! \n YOU GAINED ENOUGH FAN POWER TO BE UNSTOPPABLE \n WE WERE TRULY STRONGER TOGETHER!";
    }
}
