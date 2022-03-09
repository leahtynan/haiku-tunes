using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoemManager[] poemManagers;
    private int currentPoem;
    private int currentLine;

    void Start()
    {
        LoadPoem(0);
    }

    void Update()
    {
        if(poemManagers[currentPoem].lines[currentLine].isAnsweredCorrectly)
        {
            Debug.Log("Progress puzzle to next line");
            poemManagers[currentPoem].lines[currentLine].isAnsweredCorrectly = false;
            StartCoroutine(ProgressPuzzle(1f));
        }
    }

    public void LoadPoem(int poemNumber)
    {
        Debug.Log("Loading poem: " + currentPoem);
        currentLine = 0;
        poemManagers[currentPoem].LoadLine(currentLine);
    }

    public IEnumerator ProgressPuzzle(float WaitTime)
    {
        currentLine++;
        Debug.Log("Moving to line " + currentLine);
        //TODO:
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
