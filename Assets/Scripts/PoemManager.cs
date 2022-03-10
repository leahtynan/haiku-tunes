using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemManager : MonoBehaviour
{
    public PoemLineManager[] lines;
    public PoemViewer poemViewer;
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
        poemViewer.Toggle(true); // In the future, could be something more fancy like a fade in or words appearing one-by-one
    }

}
