using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// the state when you're using an item!
public class UseState : IState
{
    InteractableObject myObject;
    public void DoState(InputManager inputManager)
    {
        if (DidHitObject())
        {
            foreach(ReactiveObject rO in inputManager.inventory.currentItem.usableObjects)
            {
                if(myObject == rO.interactableObject)
                {
                    myObject.OnObjectUsed(rO.dialogue);
                    break;
                }
            }
        }
    }

    public bool DidHitObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {
            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.GetComponent<InteractableObject>() != null)
            {
                myObject = hit.collider.gameObject.GetComponent<InteractableObject>();
                return true;
            }
        }
        return false;
    }
}
