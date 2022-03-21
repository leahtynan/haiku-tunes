using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTileViewer : MonoBehaviour
{
    public Text letter;

    void Start()
    {
        Clear();
    }

    /* Removes the letter from the tile */
    public void Clear()
    {
        letter.text = "";
    }

    /* Fills the letter tile with the letter the user typed */
    public void Fill(char enteredLetter)
    {
        letter.text = enteredLetter.ToString();
    }
}
