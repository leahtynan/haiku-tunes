using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemManager : MonoBehaviour
{
    public PuzzleManager[] puzzles;
    public PoemViewer poemViewer;
    public BackgroundArtViewer backgroundArtViewer;
    public AudioClip fullSong;
    public GameObject haiku;

    void Start()
    {
        LoadPuzzle(0);
    }

    /* Progress to the next puzzle in the sequence of three puzzles */
    public void LoadPuzzle(int number)
    {
        foreach (PuzzleManager puzzle in puzzles)
        {
            puzzle.Toggle(false);
        }
        puzzles[number].Toggle(true);
        if (number > 0)
        {
            StartCoroutine(backgroundArtViewer.backgroundUI[number - 1].GetComponent<UIFader>().Fade(1, 0, 1.5f));
            StartCoroutine(backgroundArtViewer.backgroundUI[number].GetComponent<UIFader>().Fade(0, 1, 1.5f));
        }
        puzzles[number].puzzleViewer.ShowClueAndTiles();
    }

    /* Hide all puzzle UI and initialize poem reveal */
    public IEnumerator ShowPoem(float WaitTime)
    {
        foreach(PuzzleManager puzzle in puzzles)
        {
            puzzle.Toggle(false);
        }
        poemViewer.Toggle(true);
        StartCoroutine(poemViewer.RevealPoem(WaitTime));
        yield return null;
    }

    /* Reset UI and data for the 2nd+ time this poem is solved */
    public void Reset()
    {
        for (int i = 0; i < 3; i++)
        {
            puzzles[i].Reset();
            poemViewer.Toggle(false);
            poemViewer.haikuLines[i].GetComponent<CanvasGroup>().alpha = 0;
        }
    }

}
