using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoemManager[] poemManagers;
    public BackgroundArtViewer backgroundArtViewer;
    private int currentPoem; // The poem the user is working on
    private int currentLine; // The line in the poem the user is answering the clue for
    private int currentTile; // The letter in the answer where the user will type next
    public AudioSource audioSource;
    private bool isInteractable; // Whether the user can interact at the moment (as opposed to transitions among states)


    void Start()
    {
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
        currentPoem = poemNumber;
        currentLine = 0;
        currentTile = 0;
        isInteractable = true;
    }

    void Update()
    {
        if(isInteractable && poemManagers[currentPoem].lines[currentLine].isAnsweredCorrectly)
        {
            Debug.Log("Progress puzzle to next line");
            isInteractable = false;
            poemManagers[currentPoem].lines[currentLine].isAnsweredCorrectly = false;
            StartCoroutine(ProgressPuzzle(1f));
        }
    }

    public void EnterLetter(string letterPressed)
    {
        Debug.Log("Pressed the letter: " + letterPressed + ", filling tile #" + currentTile);
        poemManagers[currentPoem].lines[currentLine].poemLineViewer.letterTiles[currentTile].Fill(letterPressed);
        Debug.Log(poemManagers[currentPoem].lines[currentLine].correctAnswerLetters.Length);
        if(currentTile < poemManagers[currentPoem].lines[currentLine].correctAnswerLetters.Length - 1)
        {
            currentTile++;
        }
    }

    public void Delete()
    {
        Debug.Log("Deleting letter");
        poemManagers[currentPoem].lines[currentLine].poemLineViewer.letterTiles[currentTile - 1].Delete();
        currentTile--;
        Debug.Log("Current tile: " + currentTile);
    }

    public IEnumerator ProgressPuzzle(float WaitTime)
    {
        StartCoroutine(poemManagers[currentPoem].lines[currentLine].poemLineViewer.ShowSuccess(1f));
        AssignAndPlayAudio(poemManagers[currentPoem].lines[currentLine].musicalPhrase);
        currentTile = 0;
        yield return new WaitForSeconds(audioSource.clip.length);
        if (currentLine == 2)
        {
            StartCoroutine(poemManagers[currentPoem].ShowPoem(1f));
            AssignAndPlayAudio(poemManagers[currentPoem].fullSong);
        }
        else 
        {
            currentLine++;
            poemManagers[currentPoem].LoadLine(currentLine);
            isInteractable = true;
        }
    }

    public void AssignAndPlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }
}
