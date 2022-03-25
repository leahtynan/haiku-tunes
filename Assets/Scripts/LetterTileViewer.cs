using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterTileViewer : MonoBehaviour
{
    public Image background;
    public Text letter;
    public Color defaultColor;
    public Color successColor;

    void Start()
    {
        Delete();
        ChangeColor(defaultColor);
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

    /* Change tile color to green as part of success animation */
    // TODO: Might do something else later with graphics/animation
    public void ChangeColor(Color color)
    {
        background.color = color;
    }
}
