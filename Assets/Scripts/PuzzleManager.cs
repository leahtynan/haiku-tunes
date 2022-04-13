using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public PuzzleViewer puzzleViewer;
    public AudioClip musicalPhrase;
    public string clue;
    public string correctAnswer;
    public char[] correctAnswerLetters;
    public string userAnswer;
    public bool isAnsweredCorrectly; // The game manager checks this for true every frame to know when to proceed in the poem

    void Awake()
    {
        GetInputLetterAnswers();
        puzzleViewer.clueUI.text = clue;
    }

    void Update()
    {
        CheckAnswer();
    }

    /* Fill the text UI for the clue with the clue content */
    private void LoadClue()
    {
        puzzleViewer.clueUI.text = clue;
    }

    /* Splits the answer into individual letters that should be entered into each cube (like a crossword puzzle)
        e.g. "answer" -> "a", "n", "s", "w", "e", "r" */
    private void GetInputLetterAnswers()
    {
        correctAnswerLetters = correctAnswer.ToCharArray();
        //Debug.Log("The correct answer " + correctAnswer + " has " + correctAnswerLetters.Length + " letters.");
    }

    /* Checks that the answer entered for this poem line's clue is correct */
    public void CheckAnswer()
    {
        int correctAnswerCounter = 0;
        for (int i = 0; i < correctAnswerLetters.Length; i++)
        {
            //Debug.Log("Compared entered text " + poemLineViewer.letterTiles[i].letter.text + " to correct text " + correctAnswerLetters[i].ToString());
            if (puzzleViewer.letterTiles[i].letter.text.ToLower() == correctAnswerLetters[i].ToString())
            {
                correctAnswerCounter++;
            }
        }
        //Debug.Log("Number of correct letters " + correctAnswerCounter);
        if (correctAnswerCounter == correctAnswerLetters.Length)
        {
            isAnsweredCorrectly = true;
        }
    }

    /* Hides/shows entire line, inputs, and clue contained by this game object */
    public void Toggle(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }
}
