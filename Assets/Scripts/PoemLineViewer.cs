using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemLineViewer : MonoBehaviour
{
    public Text clue; // The clue that the user receives for this poem line
    public GameObject letterTiles; // All of the letter tiles for the user to fill
    public Text poemLine; // The line of the poem that shows after the correct answer is entered
    public int position; // The square the user is typing into

    public void ShowClue()
    {
        clue.enabled = true;
        letterTiles.SetActive(true);
        poemLine.enabled = false;
    }

    public void ShowSuccess()
    {
        clue.enabled = false;
        letterTiles.SetActive(false); // TODO: Later, have some success feedback/animation for the tiles
        poemLine.enabled = true;
    }

}
