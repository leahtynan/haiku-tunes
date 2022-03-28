using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemLineViewer : MonoBehaviour
{
    // TODO: Rename the script to something else now that the line is not going to be shown until the end?
    public Text clue; // The clue that the user receives for this poem line
    public LetterTileViewer[] letterTiles; // All of the letter tiles for the user to fill

    public void ShowClue()
    {
        clue.enabled = true;
        foreach(LetterTileViewer letter in letterTiles)
        {
            letter.gameObject.SetActive(true);
        }
    }

    public IEnumerator ShowSuccess(float WaitTime)
    {
        yield return new WaitForSeconds(WaitTime/2);
        for (int i = 0; i < letterTiles.Length; i++)
        {
            letterTiles[i].ChangeColor(letterTiles[i].successColor);
            yield return new WaitForSeconds(WaitTime/7);
        }
        yield return new WaitForSeconds(WaitTime * 2);
        clue.enabled = false;
        foreach (LetterTileViewer letter in letterTiles)
        {
            letter.gameObject.SetActive(false);
        }
    }

}
