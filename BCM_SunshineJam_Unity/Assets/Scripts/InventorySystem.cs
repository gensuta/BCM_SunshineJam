using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class InventorySystem : MonoBehaviour
{

    public static InventorySystem inventoryInstance;

    public List<Item> myItems = new List<Item>();
    [SerializeField] GameObject inventoryScreen, itemHolder, itemPrefab;

    public List<ItemUI> visibleItems;

    [Space]
    public Item currentItem;
    [SerializeField] bool usingItem, showingInventory;

    [Space]
    public Image itemImage;
    public TextMeshProUGUI currentItemText;

    // Start is called before the first frame update
    void Start()
    {
        if(inventoryInstance == null)
        {
            inventoryInstance = this;
        }

        currentItem = myItems[0];
        itemImage.sprite = currentItem.myIcon;
        currentItemText.text ="Current Item: " + currentItem.Name;
    }

    public void ToggleInventory()
    {
        if (!showingInventory)
        {

            inventoryScreen.SetActive(true);


            foreach (Item i in myItems)
            {
                GameObject newItem = Instantiate(itemPrefab, itemHolder.transform);
                ItemUI itemUI = newItem.GetComponent<ItemUI>();
                itemUI.SetUp(i);
                visibleItems.Add(itemUI);
            }

            showingInventory = true;
        }
        else
        {
            HideInventory();
        }
    }

    public void HideInventory()
    {
        inventoryScreen.SetActive(false);

        foreach (ItemUI g in visibleItems)
        {
            Destroy(g.gameObject);
        }
        visibleItems.Clear();
        showingInventory = false;

        itemImage.sprite = currentItem.myIcon;
    }

    public void UseItem()
    {
        usingItem = true;
        HideInventory();
        InputManager.inputInstance.currentState = InputManager.inputInstance.useState;

        itemImage.color = Color.yellow;
    }

    public void StopUsingItem()
    {
        usingItem = false;
        itemImage.color = Color.white;
    }


}
