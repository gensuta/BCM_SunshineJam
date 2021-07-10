using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : InteractableObject
{
    public Sprite myIcon;

    //effectedObject is what we're using the current object on
    public void UseItem(InteractableObject effectedObject)
    {
        // we need text or w/e for when items or used. figure it out better
    }
}

// Separated this into two classes so that the item object people can manipulate in the project while
// if we need to create a new Item in the middle of the game it doesn't get weird bc you know...
// Scriptable Objects are funky :S

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Item", order = 0)]
public class ItemObject : ScriptableObject
{
    public Item item;
}
