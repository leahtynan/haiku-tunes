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

    public void LoadLine(int lineNumber)
    {
        foreach (PoemLineManager line in lines)
        {
            line.Toggle(false);
        }
        lines[lineNumber].Toggle(true);
        if (lineNumber > 0)
        {
            backgroundArtViewer.poemLinePuzzleBackgrounds[lineNumber - 1].GetComponent<UIFader>().Fade(1, 0, 1f);
            backgroundArtViewer.poemLinePuzzleBackgrounds[lineNumber].GetComponent<UIFader>().Fade(0, 1, 1f);
        }
        lines[lineNumber].poemLineViewer.ShowClue();
    }

    public IEnumerator ShowPoem(float WaitTime)
    {
        foreach(PoemLineManager line in lines)
        {
            line.Toggle(false);
        }
        yield return (WaitTime);
        haiku.SetActive(true);
        poemViewer.Toggle(true); // TODO: Replace this basic toggle on with a typewriter effect
    }

}
