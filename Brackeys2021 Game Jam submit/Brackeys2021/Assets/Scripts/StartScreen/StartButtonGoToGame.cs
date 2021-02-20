using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonGoToGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GoToGame()
    {
        gameObject.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("FightWithScripts");
    }
}
