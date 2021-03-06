using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleViewer : MonoBehaviour
{
    public Text clueUI; // Text showing the clue for this puzzle
    public LetterTileViewer[] letterTiles; // All of the letter tiles for the user to fill
    public Sprite backgroundImage; // 1920x1080 image that is the background when this poem line's puzzle is active
    public Sprite triptychPanel; // 620x1080 version of the background image that shows when the entire haiku is revealed

    /* Shows the clue of the puzzle and tiles to fill in its answer */
    public void ShowClueAndTiles()
    {
        clueUI.enabled = true;
        foreach (LetterTileViewer letter in letterTiles)
        {
            letter.gameObject.SetActive(true);
        }
    }

    /* Animates tiles from left-to-right when the correct answer is entered */
    public IEnumerator ShowSuccess(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime / 2);
        for (int i = 0; i < letterTiles.Length; i++)
        {
            letterTiles[i].ShowSuccessLook();
            yield return new WaitForSeconds(WaitTime / 8);
        }
        yield return new WaitForSeconds(WaitTime * 2);
        clueUI.enabled = false;
        foreach (LetterTileViewer letter in letterTiles)
        {
            letter.gameObject.SetActive(false);
        }
    }

    /* Clears letters and success graphics from tiles */
    public void ResetTiles()
    {
        foreach(LetterTileViewer tile in letterTiles)
        {
            tile.Reset();
        }
    }
}
