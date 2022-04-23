using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public PoemViewer poemViewer;
    public PuzzleViewer puzzleViewer;
    public AudioClip musicalPhrase;
    public string clue;
    public string correctAnswer;
    public char[] correctAnswerLetters;
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
        bool areAllTilesFilled = AreAllTilesFilled();
        for (int i = 0; i < correctAnswerLetters.Length; i++)
        {
            if (puzzleViewer.letterTiles[i].letter.text.ToLower() == correctAnswerLetters[i].ToString())
            {
                correctAnswerCounter++;
            }
        }
        // Trigger success state
        if (correctAnswerCounter == correctAnswerLetters.Length)
        {
            isAnsweredCorrectly = true;
        }
        // Trigger feedback state
        else if (correctAnswerCounter < correctAnswerLetters.Length && areAllTilesFilled == true)
        {
            poemViewer.feedback.text = "The answer ______ is not correct. *hint*";
        } 
        // Remove feedback state if the user has not filled all the tiles, or if letters have been deleted following an incorrect answer
        else if(correctAnswerCounter < correctAnswerLetters.Length && areAllTilesFilled == false)
        {
            poemViewer.feedback.text = "";

        }
    }

    /* Checks that all tiles have text in them */
    public bool AreAllTilesFilled()
    {
        bool areFilled = false;
        int counter = 0;
        foreach(LetterTileViewer tile in puzzleViewer.letterTiles)
        {
            if(tile.isFilled)
            {
                counter++;
            }
        }
        if(counter == correctAnswerLetters.Length)
        {
            areFilled = true;
        }
        return areFilled;
    }


    /* Hides/shows entire line, inputs, and clue contained by this game object */
    public void Toggle(bool isActive)
    {
        this.gameObject.SetActive(isActive);
    }

    /* Resets solved status and UI for the case where the user loops back and plays this puzzle again */
    public void Reset()
    {
        Debug.Log("resetting puzzle");
        puzzleViewer.ResetTiles();
        isAnsweredCorrectly = false;
    }
}
