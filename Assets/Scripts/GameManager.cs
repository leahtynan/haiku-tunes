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
    private int currentLine; // The line in the poem the user is answering the clue for
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
        currentLine = 0;
        currentTile = 0;
        isInteractable = true;
        isShowingHaiku = false;
    }

    /* Continuously checks for correctly entered answers */
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

    /* Enters a letter into the current tile and moves to the next tile (unless user is on the last tile) */
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

    /* Deletes the letter from the current tile and moves to the previous tile */
    public void Delete()
    {
        Debug.Log("Deleting letter at position: " + currentTile);
        poemManagers[currentPoem].lines[currentLine].poemLineViewer.letterTiles[currentTile].Delete();
        if (currentTile > 0)
        {
            currentTile--;
        }
        Debug.Log("Current tile: " + currentTile);
    }

    /* Transitions to the next poem line puzzle or (if the last clue was solved) show the poem and offer option to solve next one */
    public IEnumerator ProgressPuzzle(float WaitTime)
    {
        StartCoroutine(poemManagers[currentPoem].lines[currentLine].poemLineViewer.ShowSuccess(1f));
        AssignAndPlayAudio(poemManagers[currentPoem].lines[currentLine].musicalPhrase);
        currentTile = 0;
        yield return new WaitForSeconds(audioSource.clip.length);
        if (currentLine == 2)
        {
            isShowingHaiku = true;
            float timePoemShowing = 0f;
            StartCoroutine(poemManagers[currentPoem].backgroundArtViewer.DisplayTriptych(1f));
            StartCoroutine(poemManagers[currentPoem].ShowPoem(1f));
            AssignAndPlayAudio(poemManagers[currentPoem].fullSong);
            yield return new WaitForSeconds(audioSource.clip.length - 1f); // Wait until a second before the song finishes playing
            ShowNextButton();
            // TODO: Loop the song until the user presses the "Next" button
            // while(showingHaiku) {
            //
            // }
 
        }
        else 
        {
            currentLine++;
            poemManagers[currentPoem].LoadLine(currentLine);
            isInteractable = true;
        }
    }

    /* Sets the mp3 to play and plays it */
    public void AssignAndPlayAudio(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    /* Fades in the "Next" button that enables user to move to next poem */
    public void ShowNextButton()
    {
        StartCoroutine(nextButton.GetComponent<UIFader>().Fade(0, 1, 1f));
    }
}
