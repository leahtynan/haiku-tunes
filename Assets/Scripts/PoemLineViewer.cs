using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemLineViewer : MonoBehaviour
{
    // TODO: Set up row of squares to fill letters in like a crossword puzzle
    public Text clue; // The clue that the user receives for this poem line
    public Text poemLine; // The line of the poem that shows after the correct answer is entered
    public int position; // The square the user is typing into

    public void ShowClue()
    {
        clue.enabled = true;
        //foreach (InputField input in userInputs)
        //{
        //    input.gameObject.SetActive(true);
        //}
        poemLine.enabled = false;
    }

    public void ShowSuccess()
    {
        // TODO:
        // Text for current clue’s input becomes green and non - interactable
        clue.enabled = false;
        //foreach(InputField input in userInputs)
        //{
        //    input.gameObject.SetActive(false);
        //}
        poemLine.enabled = true;
    }

}
