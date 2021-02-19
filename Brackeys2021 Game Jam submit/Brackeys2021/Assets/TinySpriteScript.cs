using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinySpriteScript : MonoBehaviour
{
    ItemData data;
    private void Awake()
    {
        data = this.GetComponent<Item>().itemData;
    }
    private void OnMouseOver()
    {
        GameObject.Find("Canvas").transform.Find("ItemHover").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("ItemHover").gameObject.GetComponent<Item>().itemData = data;
    }

    private void OnMouseExit()
    {
        GameObject.Find("Canvas").transform.Find("ItemHover").gameObject.SetActive(false);
    }
}
