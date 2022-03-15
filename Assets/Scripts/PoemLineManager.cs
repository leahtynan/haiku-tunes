using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemLineManager : MonoBehaviour
{
    public PoemLineViewer poemLineViewer;
    public AudioClip musicalPhrase;
    public string correctAnswer;
    public char[] correctAnswerLetters;
    public string userAnswer;
    public bool isAnsweredCorrectly; // The game manager checks this for true every frame to know when to proceed in the poem
    // TODO: Number of letters in the answer? To give user extra clue. Also, may tie into UI like how crossword puzzles have number of visible cubes to fill.


    void Start()
    {
        GetInputLetterAnswers();
    }

    /* Splits the answer into individual letters that should be entered into each cube (like a crossword puzzle)
        e.g. "answer" -> "a", "n", "s", "w", "e", "r" */
    private void GetInputLetterAnswers()
    {
        correctAnswerLetters = correctAnswer.ToCharArray();
    }

    /* Checks that the answer entered for this poem line's clue is correct */
    public void CheckAnswer()
    {
        // TODO: Modify this to loop through several inputs */
        userAnswer = poemLineViewer.userInput.text;
        int correctAnswerCounter = 0;
        //while(correctAnswerCounter < correctAnswerLetters.Length + 1)
        //{
        //    for (int i = 0; i < correctAnswerLetters.Length; i++)
        //    {
        //        if (poemLineViewer.userInputs[i].text == correctAnswerLetters[i])
        //        {
        //            correctAnswerCounter++;
        //        }
        //    }
        //}
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

    /* Hides/shows entire line, inputs, and clue contained by this game object */
    public void Toggle(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

}
