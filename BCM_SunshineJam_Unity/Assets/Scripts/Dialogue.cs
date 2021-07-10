using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "New Dialogue/Dialogue", order = 0)]
public class Dialogue : ScriptableObject
{
    [TextArea(2,5)]
    public string[] myLines; // these strings either need to be something else OR we need to tie character names to images

    [Space]

    public bool hasSeenDialogue;
    public Dialogue nextLines; // if we've seen myLines, we can display nextLines.

}
