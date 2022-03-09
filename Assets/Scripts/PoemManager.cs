using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemManager : MonoBehaviour
{
    // References
    public PoemLineManager[] lines;

    // Poem content
    public string[] haiku;
    public AudioClip[] musicalPhrases;
    public AudioClip fullSong;

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
        // TODO:
        // Hide the input UI for the third line
        yield return (WaitTime);
        // Show the haiku
        // Play the full song, looping indefinitely
        // Provide UI to proceed to next poem
    }

}
