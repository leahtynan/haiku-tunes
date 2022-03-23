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

    void Start()
    {
        GetInputLetterAnswers();
    }

    void Update()
    {
        CheckAnswer();
    }

    /* Splits the answer into individual letters that should be entered into each cube (like a crossword puzzle)
        e.g. "answer" -> "a", "n", "s", "w", "e", "r" */
    private void GetInputLetterAnswers()
    {
        correctAnswerLetters = correctAnswer.ToCharArray();
        Debug.Log("The correct answer " + correctAnswer + " has " + correctAnswerLetters.Length + " letters.");
    }

    /* Checks that the answer entered for this poem line's clue is correct */
    public void CheckAnswer()
    {
        int correctAnswerCounter = 0;
        //while (correctAnswerCounter < correctAnswerLetters.Length + 1)
        //{
        //    for (int i = 0; i < correctAnswerLetters.Length; i++)
        //    {
        //        //if (poemLineViewer.userInputs[i].text == correctAnswerLetters[i].ToString())
        //        //{
        //        //    correctAnswerCounter++;
        //        //}
        //    }
        //}
        //Debug.Log("User's answer: " + userAnswer);
        //if(userAnswer == correctAnswer)
        //{
        //    isAnsweredCorrectly = true;
        //    Debug.Log(userAnswer + " is correct");
        //} else
        //{
        //    isAnsweredCorrectly = false;
        //    Debug.Log(userAnswer + " is not correct");
        //}
    }

    /* Hides/shows entire line, inputs, and clue contained by this game object */
    public void Toggle(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

}
