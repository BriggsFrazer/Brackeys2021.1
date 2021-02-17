using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTracker : MonoBehaviour
{
    public List<GameObject> allItems;
    public GameObject ItemHolder;
    public List<GameObject> chosenItems;

    public void Start()
    {

        for (int i = 0; i < ItemHolder.transform.childCount; i++)
        {
            allItems.Add(ItemHolder.transform.GetChild(i).gameObject);
        }

        Debug.Log(allItems);
        ChooseNextThree();
    }

    public void ChooseNextThree() {
        chosenItems.Clear();


        for (int i = 0; i < 3; i++)
        {
            int id = Random.Range(0, allItems.Count);
            foreach(var item in allItems)
            {
               var ItemData = item.GetComponent<Item>().itemData.id;
               if (ItemData == id) { 
                    chosenItems.Add(item);
                    
                }
            }
        }


    }

}
