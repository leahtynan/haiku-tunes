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
        currentLine = 0;
        LoadPoem(0);
        // Note: In the future, might consider randomizing poems if a lot of content is available.
        // For now, just progress linearly
    }

    void LoadPoem(int poemNumber)
    {
        foreach (PoemManager poem in poemManagers)
        {
            poem.gameObject.SetActive(false);
        }
        poemManagers[poemNumber].gameObject.SetActive(true);
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

    public IEnumerator ProgressPuzzle(float WaitTime)
    {
        poemManagers[currentPoem].lines[currentLine].poemLineViewer.ShowSuccess();
        // TODO: Play musical phrase for this poem's line n
        yield return (2 * WaitTime); // TODO: Later, make this pause the length of the musical phrase, plus a little extra
        if (currentLine == 2)
        {
            StartCoroutine(poemManagers[currentPoem].ShowPoem(1f));
        }
        else 
        {
            currentLine++;
            Debug.Log("Moving to line " + currentLine);
            poemManagers[currentPoem].LoadLine(currentLine);
        }
    }
}
