using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemLineViewer : MonoBehaviour
{
    public Text clue; // The clue that the user receives for this poem line
    public LetterTileViewer[] letterTiles; // All of the letter tiles for the user to fill
    public Sprite backgroundImage; // 1920x1080 image that is the background when this poem line's puzzle is active
    public Sprite triptychPanel; // 620x1080 version of the background image that shows when the entire haiku is revealed

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
            yield return new WaitForSeconds(WaitTime/8);
        }
        yield return new WaitForSeconds(WaitTime * 2);
        clue.enabled = false;
        foreach (LetterTileViewer letter in letterTiles)
        {
            letter.gameObject.SetActive(false);
        }
    }

}
