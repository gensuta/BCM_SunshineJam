using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvestigateState : IState
{
    InteractableObject myObject;
    public void DoState(InputManager inputManager)
    {
        // switch state to dialogue if myObject != null
        // then run dialogueState

        if (DidHitObject())
        {
            myObject.OnObjectClicked();

            if (myObject.canBePickedUp)
            {
                inputManager.dialogueRunner.objectToBeDeleted = myObject;
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
