using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemLineManager : MonoBehaviour
{
    public PoemLineViewer poemLineViewer;
    public string correctAnswer;
    public string userAnswer;
    public bool isAnsweredCorrectly;
    // TODO: Number of letters in the answer? To give user extra clue. Also, may tie into UI like how crossword puzzles have number of visible cubes to fill.

    public void CheckAnswer()
    {
        userAnswer = poemLineViewer.userInput.text;
        Debug.Log("User's answer: " + userAnswer);
        if(userAnswer == correctAnswer)
        {
            isAnsweredCorrectly = true;
            Debug.Log(userAnswer + " is correct");
        } else
        {
            isAnsweredCorrectly = false;
            Debug.Log(userAnswer + " is not correct");
        }
 
    }

}
