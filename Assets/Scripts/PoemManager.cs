using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemManager : MonoBehaviour
{
    public PoemLineManager[] lines;
    public PoemViewer poemViewer;
    public BackgroundArtViewer backgroundArtViewer;
    public AudioClip fullSong;
    public GameObject haiku;

    void Start()
    {
        LoadLine(0);
    }

    /* Progress to the next puzzle in the sequence of three puzzles */
    public void LoadLine(int lineNumber)
    {
        foreach (PoemLineManager line in lines)
        {
            line.Toggle(false);
        }
        lines[lineNumber].Toggle(true);
        if (lineNumber > 0)
        {
            StartCoroutine(backgroundArtViewer.poemLinePuzzleBackgrounds[lineNumber - 1].GetComponent<UIFader>().Fade(1, 0, 1.5f));
            StartCoroutine(backgroundArtViewer.poemLinePuzzleBackgrounds[lineNumber].GetComponent<UIFader>().Fade(0, 1, 1.5f));
        }
        lines[lineNumber].poemLineViewer.ShowClueAndTiles();
    }

    /* Hide all puzzle UI and initialize poem reveal */
    public IEnumerator ShowPoem(float WaitTime)
    {
        foreach(PoemLineManager line in lines)
        {
            line.Toggle(false);
        }
        yield return (WaitTime);
        poemViewer.Toggle(true);
        StartCoroutine(poemViewer.RevealPoem());
    }

}
