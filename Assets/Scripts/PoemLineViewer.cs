using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemLineViewer : MonoBehaviour
{
    public InputField userInput;
    public Text clue;
    public Text poemLine;

    public void ShowSuccess()
    {
        // TODO:
        // Text for current clue’s input becomes green and non - interactable
        // Play musical phrase for that clue/ answer set
        // Show line of Haiku
    }

    public void ToggleLine(bool isShowing)
    {
        if(isShowing)
        {
            // TODO: Show the clue and input 
        } else
        {
            // TODO: Hide the clue and input
        }
    }
}
