using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonPopupScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Canvas").transform.Find("PopUp").gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ShowPopUp()
    {
        GameObject.Find("Canvas").transform.Find("PopUp").gameObject.SetActive(true);
    }
}
