using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    private Color[] colors = { Color.white, new Color(0.1725f, 1, 0.98f), new Color(0.227f, 1, 0.6f), new Color(1, 0.741f, 0), new Color(1, 0.584f, 0.871f), Color.green };
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        var itemData = this.GetComponent<Item>().itemData;

        this.gameObject.transform.Find("Card").gameObject.transform.Find("TitleText").GetComponent<UnityEngine.UI.Text>().text = (itemData.itemName);

        this.gameObject.transform.Find("Card").gameObject.transform.Find("ItemIcon").GetComponent<UnityEngine.UI.Image>().sprite = (itemData.bigSprite);

        this.gameObject.transform.Find("Card").gameObject.transform.Find("Border").GetComponent<UnityEngine.UI.Image>().color = colors[itemData.demographicID];

        this.gameObject.transform.Find("Card").gameObject.transform.Find("Description").GetComponent<UnityEngine.UI.Text>().text = itemData.description;
    }
}
