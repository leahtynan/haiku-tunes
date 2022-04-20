using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTileViewer : MonoBehaviour
{
    public Image background;
    public Sprite defaultLook;
    public Sprite successLook;
    public Text letter;

    void Start()
    {
        Reset();
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

    /* Change the tile background to plain white */
    public void ShowDefaultLook()
    {
        background.sprite = defaultLook;
    }

    /* Change the tile background to a green gradient look as part of success animation */
    public void ShowSuccessLook()
    {
        background.sprite = successLook;
    }

    /* Clear letter and success graphics from the tile */
    public void Reset()
    {
        Delete();
        ShowDefaultLook();
    }
}
