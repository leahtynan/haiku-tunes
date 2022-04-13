using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public PoemManager[] poemManagers;
    public AudioSource audioSource;
    public GameObject nextButton;

    [Header("Game Play Data")]
    private int currentPoem; // The poem the user is working on
    private int currentPuzzle; // The puzzle the user is solving (out of 3 total puzzles per poem)
    private int currentTile; // The letter in the answer where the user will type next
    private bool isInteractable; // Whether the user can interact at the moment (i.e. UI isn't in transition)
    private bool isShowingHaiku; // Whether the user is still on the haiku (the final state) - condition for continuing to loop audio

    void Start()
    {
        LoadPoem(0);
        // Note: In the future, might consider randomizing poems if a lot of content is available.
        // For now, just progress linearly
    }

    /* Loads UI for a poem and resets the game play data */
    // TODO: This should be set up as a callback function triggered when the "Next" button is clicked
    public void LoadPoem(int poemNumber)
    {
        foreach (PoemManager poem in poemManagers)
        {
            poem.gameObject.SetActive(false);
        }
        poemManagers[poemNumber].gameObject.SetActive(true);
        poemManagers[poemNumber].backgroundArtViewer.Initialize();
        nextButton.GetComponent<CanvasGroup>().alpha = 0;
        currentPoem = poemNumber;
        currentPuzzle = 0;
        currentTile = 0;
        isInteractable = true;
        isShowingHaiku = false;
        audioSource.loop = false;
    }

    /* Moves to next poem. This is used as a callback upon pressing the "Next" button in the haiku state of a poem */
    public void GoToNextPoem()
    {
        audioSource.Stop();
        currentPoem++;
        ShowNextButton(false);
        LoadPoem(currentPoem);
    }

    /* Continuously checks for correctly entered answers */
    void Update()
    {
        if(isInteractable && poemManagers[currentPoem].puzzles[currentPuzzle].isAnsweredCorrectly)
        {
            isInteractable = false;
            poemManagers[currentPoem].puzzles[currentPuzzle].isAnsweredCorrectly = false;
            StartCoroutine(ProgressPuzzle(1f));
        }
    }

    /* Enters a letter into the current tile and moves to the next tile (unless user is on the last tile) */
    public void EnterLetter(string letterPressed)
    {
        Debug.Log("Pressed the letter: " + letterPressed + ", filling tile #" + currentTile);
        poemManagers[currentPoem].puzzles[currentPuzzle].puzzleViewer.letterTiles[currentTile].Fill(letterPressed);
        Debug.Log(poemManagers[currentPoem].puzzles[currentPuzzle].correctAnswerLetters.Length);
        if(currentTile < poemManagers[currentPoem].puzzles[currentPuzzle].correctAnswerLetters.Length - 1)
        {
            currentTile++;
        }
    }

    /* Deletes the letter from the current tile and moves to the previous tile */
    public void Delete()
    {
        Debug.Log("Deleting letter at position: " + currentTile);
        poemManagers[currentPoem].puzzles[currentPuzzle].puzzleViewer.letterTiles[currentTile].Delete();
        if (currentTile > 0)
        {
            currentTile--;
        }
        Debug.Log("Current tile: " + currentTile);
    }

    /* Transitions to the next poem line puzzle or (if the last clue was solved) show the poem and offer option to solve next one */
    public IEnumerator ProgressPuzzle(float WaitTime)
    {
        StartCoroutine(poemManagers[currentPoem].puzzles[currentPuzzle].puzzleViewer.ShowSuccess(1f));
        AssignAndPlayAudio(poemManagers[currentPoem].puzzles[currentPuzzle].musicalPhrase);
        currentTile = 0;
        yield return new WaitForSeconds(audioSource.clip.length);
        if (currentPuzzle == 2)
        {
            isShowingHaiku = true;
            float timePoemShowing = 0f;
            StartCoroutine(poemManagers[currentPoem].backgroundArtViewer.DisplayTriptych(1f));
            StartCoroutine(poemManagers[currentPoem].ShowPoem(1f));
            AssignAndPlayAudio(poemManagers[currentPoem].fullSong);
            yield return new WaitForSeconds(audioSource.clip.length - 1f); // Wait until a second before the song finishes playing
            ShowNextButton(true);
            audioSource.loop = true;
        }
        else 
        {
            currentPuzzle++;
            poemManagers[currentPoem].LoadPuzzle(currentPuzzle);
            isInteractable = true;
        }
    }

    /* Sets the mp3 to play and plays it */
    public void AssignAndPlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    /* Fades in/out the "Next" button */
    public void ShowNextButton(bool isShowing)
    {
        if(isShowing)
        {
            StartCoroutine(nextButton.GetComponent<UIFader>().Fade(0, 1, 1f));
        } else
        {
            StartCoroutine(nextButton.GetComponent<UIFader>().Fade(1, 0, 1f));
        }
    }
}
