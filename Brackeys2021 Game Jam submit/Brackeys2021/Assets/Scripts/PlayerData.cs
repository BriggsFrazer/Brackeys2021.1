using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public List<GameObject> PlayerItems;
    public void AddItem(int itemToAdd) {
        PlayerItems.Add(this.GetComponent<ItemTracker>().chosenItems[itemToAdd]);
    }

}
