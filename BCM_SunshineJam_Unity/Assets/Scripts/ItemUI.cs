using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Item myItem;

    public void SetUp(Item i)
    {
        myItem = i;
        if (i.myIcon != null)
        {
            GetComponent<Image>().sprite = i.myIcon;
            gameObject.name = i.Name;
        }
    }


    public void ChooseItem()
    {
        InventorySystem.inventoryInstance.currentItem = myItem;
        InventorySystem.inventoryInstance.currentItemText.text = "Current Item: " + InventorySystem.inventoryInstance.currentItem.Name;
    }


  
}
