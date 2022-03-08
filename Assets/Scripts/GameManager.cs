using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoemManager[] poemManagers;
    private int currentPoem;
    private int currentLine;
    private int numberCluesSolved; // currentLine and numberCluesSolved are a bit redundant, but keep both for now for clarity

    void Start()
    {
        LoadPoem(0);
    }  

    public void LoadPoem(int poemNumber)
    {
        Debug.Log("Loading poem: " + currentPoem);
        numberCluesSolved = 0;
        //Show first line of the poem, i.e.poemManagers[currentPoem].ShowLine(0)
    }

    public IEnumerator SubmitAnswer(float WaitTime)
    {
        //TODO:
        // Every frame, check to see if the current line is answered (poemManagers[currentPoem].lines[currentLine].isAnswered) 
        // If answer is incorrect:
        // Show error message
        // UI change(such as highlighting incorrect tiles)
        // If answer is correct:
        // Run ShowSuccess(numberCluesSolved)
        // If this is the first or second correct answer:
        // Progress to the next piece of content after a short pause
        yield return (WaitTime);
        // If this is the third correct answer:
        // Hide the input UI
        // Show the haiku
        // Play the full song
        // UI to proceed to next poem
    }
}
