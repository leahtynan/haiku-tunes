using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemManager : MonoBehaviour
{
    // References
    public PoemLineManager[] lines;
    public PoemViewer poemViewer;

    // Poem content
    public AudioClip[] musicalPhrases;
    public AudioClip fullSong;

    void Start()
    {
        LoadLine(0);
    }

    public void LoadLine(int lineNumber)
    {
        foreach(PoemLineManager line in lines)
        {
            line.Toggle(false);
        }
        lines[lineNumber].Toggle(true);
        lines[lineNumber].poemLineViewer.ShowClue();
    }

    public IEnumerator ShowPoem(float WaitTime)
    {
        foreach(PoemLineManager line in lines)
        {
            line.Toggle(false);
        }
        yield return (WaitTime);
        poemViewer.Toggle(true);
        // Play the full song, looping indefinitely
        // Provide UI to proceed to next poem
    }

}
