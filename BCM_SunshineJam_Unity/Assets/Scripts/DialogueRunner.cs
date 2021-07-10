using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class DialogueRunner : MonoBehaviour
{
    public InteractableObject objectToBeDeleted; // if we're adding smthg to the inventory we should delete it after the last line!!

    [Space]
    public InputManager inputManager;
    public Dialogue currentDialogue;

    [Header("Textbox Objects")]
    public GameObject textBox;
    public TextMeshProUGUI _text;
    public TextMeshProUGUI nameTxt;
    public Image img; // shows whos taalking

    public int currentLine;
    public float textSpeed;

    [Space]
    [Header("Dialogue Runner Bools")]
    bool isTyping = false;
    bool cancelTyping = false;
    public bool isActive;// are things showing?
    public bool already; // did you press space already?


    public void Continue()
    {
        if (isActive)
        {
            if (already)
            {
                if (!isTyping) // if no text is typing go to next line OR disable textbox
                {
                    currentLine += 1;
                    if (currentLine >= currentDialogue.myLines.Length)
                    {
                        DisableTextBox();
                    }
                    else
                    {
                        StartCoroutine(Textscroll(currentDialogue.myLines[currentLine]));
                    }
                }
                else if (isTyping && !cancelTyping) // cancel typing!
                {
                    cancelTyping = true;
                    already = false;
                }
            }
            else
            {
                already = true; // you pressed space already
            }
        }
    }


    public void EnableTextBox(Dialogue dialogue)
    {
        isActive = true;
        currentLine = 0;
        currentDialogue = dialogue;
        textBox.SetActive(true);
        StartCoroutine(Textscroll(currentDialogue.myLines[currentLine]));
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        inputManager.currentState = inputManager.investigateState;

        if (objectToBeDeleted != null)
        {
            objectToBeDeleted.AddToInventory();
        }

        InventorySystem.inventoryInstance.StopUsingItem();

        currentDialogue.hasSeenDialogue = true;
        currentDialogue = null;
    }


    private IEnumerator Textscroll(string lineoftext)
    {
        int letter = 0;
        _text.maxVisibleCharacters = 0;

        _text.text = lineoftext;

        isTyping = true;
        cancelTyping = false;

        while (isTyping && !cancelTyping && (letter < _text.text.Length - 1))
        {
            letter += 1;
            _text.maxVisibleCharacters = letter;
            yield return new WaitForSeconds(textSpeed);
        }

        _text.maxVisibleCharacters = _text.text.Length;
        isTyping = false;
        cancelTyping = false;
    }

}
