using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTileViewer : MonoBehaviour
{
    public Text letter;

    void Start()
    {
        Delete();
    }

    /* Removes the letter from the tile */
    public void Delete()
    {
        letter.text = "";
    }

    /* Fills the letter tile with the letter the user typed */
    public void Fill(string enteredLetter)
    {
        letter.text = enteredLetter.ToUpper();
    }
}
