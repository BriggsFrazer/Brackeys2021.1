using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTracker : MonoBehaviour
{
    public List<GameObject> allItems;
    public GameObject defaultItem;
    public GameObject ItemHolder;
    public List<GameObject> chosenItems;

    public int itemCount;

    public void Start()
    {


    }

    public void PopulateAllItem()
    {

        for (int i = 0; i < GameObject.Find("ItemHolder").transform.childCount; i++)
        {
            allItems.Add(GameObject.Find("ItemHolder").transform.GetChild(i).gameObject);
        }

        itemCount = GameObject.Find("ItemHolder").transform.childCount;

        Debug.Log(allItems);
        //ChooseNextThree();
    }

    public void ChooseNextThree() {

        if (PlayerData.PlayerItems.Count >= 1 )
        {
            for (int i = 0; i < 3; i++)
            {
                if (chosenItems[i].GetComponent<Item>().itemData.id != PlayerData.PlayerItems[PlayerData.PlayerItems.Count - 1].GetComponent<Item>().itemData.id && chosenItems[i].GetComponent<Item>().itemData.name != "DefaultItem")
                {
                    allItems.Add(chosenItems[i]);
                }
            }
        }

        chosenItems.Clear();

        Random.InitState(System.DateTime.Now.Millisecond);

        for (int i = 0; i < 3; i++)
        {
            int id = Random.Range(0, itemCount);
            bool found = false;
            foreach(var item in allItems)
            {
               var ItemData = item.GetComponent<Item>().itemData.id;
               if (ItemData == id) { 
                    chosenItems.Add(item);
                    found = true;
                }
            }
            if (found == false)
            {
                chosenItems.Add(defaultItem);
            }
            else
            {
                bool removed = false;
                foreach (var item in allItems)
                {
                    var ItemData = item.GetComponent<Item>().itemData.id;
                    if (ItemData == id)
                    {
                        allItems.Remove(item);
                        removed = true;
                    }
                    if (removed)
                    {
                        break;
                    }
                }
            }
        }


    }

}
