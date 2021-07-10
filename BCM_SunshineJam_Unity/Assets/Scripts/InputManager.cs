using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static InputManager inputInstance;

    public InventorySystem inventory; // stores the items we have and displays them
    public DialogueRunner dialogueRunner;

    public IState currentState;

    public UseState useState = new UseState();
    public MoveState moveState = new MoveState();
    public InvestigateState investigateState = new InvestigateState();
    public DialogueState dialogueState = new DialogueState();


    // for every click we just do currentState.DoState
    // for Move we go to a new location. Map is on the screen!
    // for DialogueState it just proceeds to the next line of text! When disabled we return to investigate
    // for Investiagte we just keep seeing if we interact with smthg ( if u click and nothing hits, nothing to see here )
    // for Use it's similar to investigate but 

    void Start()
    {
        currentState = investigateState;

        if (inputInstance == null)
        {
            inputInstance = this;
        }

        if (inputInstance != this)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // check did hit object in investigate
        // in dialogue proceed the text!!
        // 

        if (Input.GetMouseButtonDown(0))
        {
            currentState.DoState(this);
        }

        // we switch current state to move when we click on the map button
        // we switch current state to use when we click to use an object in the inventory
        // we switch current state to dialogue everytime we go to dostate and actually hit a thingy
        // we go back to investigate automatically once we finish a dialogue thingy

        // we need an on hover type thing. when hovering over an actual object display the name or ??? ykno?



    }



}
