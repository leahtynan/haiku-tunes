using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemLineViewer : MonoBehaviour
{
    public Text clue; // The clue that the user receives for this poem line
    public LetterTileViewer[] letterTiles; // All of the letter tiles for the user to fill
    public Text poemLine; // The line of the poem that shows after the correct answer is entered

    public void ShowClue()
    {
        clue.enabled = true;
        foreach(LetterTileViewer letter in letterTiles)
        {
            letter.gameObject.SetActive(true);
        }
        poemLine.enabled = false;
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
        poemLine.enabled = true;
    }

}
