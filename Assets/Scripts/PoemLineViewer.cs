using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemLineViewer : MonoBehaviour
{
    public InputField userInput;
    public Text clue;
    public Text poemLine;

    public void ShowClue()
    {
        clue.enabled = true;
        userInput.enabled = true;
        poemLine.enabled = false;
    }

    public void ShowSuccess()
    {
        // TODO:
        // Text for current clue�s input becomes green and non - interactable
        // Play musical phrase for that clue/ answer set
        // Show line of Haiku
    }

}
