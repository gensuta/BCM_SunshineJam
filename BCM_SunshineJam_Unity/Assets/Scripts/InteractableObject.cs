using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    [SerializeField] string objectName;
    public bool canBeCombined, canBePickedUp;

    public ReactiveObject[] combinableObjects;
    public ReactiveObject[] usableObjects; // these objects react if we use THIS object on one of them

    public Dialogue dialogue;

    public string Name { get => objectName; }


    public void OnObjectClicked()
    {
        InputManager inputManager = InputManager.inputInstance;

        inputManager.currentState = inputManager.dialogueState;
        inputManager.dialogueRunner.EnableTextBox(this.dialogue);

        // if in investigate state show dialogue if in use state, try to use object or some shit, OR also check if
        // some prev knowledge has been uncovered!! ykno?
    }

    public void OnObjectUsed(Dialogue usedDialogue)
    {
        InputManager inputManager = InputManager.inputInstance;

        inputManager.currentState = inputManager.dialogueState;
        inputManager.dialogueRunner.EnableTextBox(usedDialogue);

    }

    public void AddToInventory()
    {
        Item myItem = (Item)this;
        InputManager.inputInstance.inventory.myItems.Add(myItem);
        Destroy(this.gameObject);
    }
}
