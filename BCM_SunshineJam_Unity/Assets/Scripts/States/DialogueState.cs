using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueState : IState
{
    public void DoState(InputManager inputManager)
    {
        // run dialogue via dialogue runner
        //if can be picked up, add to inventory

        inputManager.dialogueRunner.Continue();
    }
    
}
