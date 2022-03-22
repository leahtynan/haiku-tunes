using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManager : MonoBehaviour
{
    public GameManager gameManager;

    void Update()
    {
        // TODO: Is there a more elegant way to do this?
        if (Input.GetKeyDown(KeyCode.A))
        {
            EnterLetter("a");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            EnterLetter("b");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            EnterLetter("c");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            EnterLetter("d");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            EnterLetter("e");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            EnterLetter("f");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            EnterLetter("g");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            EnterLetter("h");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            EnterLetter("i");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            EnterLetter("j");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            EnterLetter("k");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            EnterLetter("l");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            EnterLetter("m");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            EnterLetter("n");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            EnterLetter("o");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            EnterLetter("p");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            EnterLetter("q");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            EnterLetter("r");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            EnterLetter("s");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            EnterLetter("t");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            EnterLetter("u");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            EnterLetter("v");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            EnterLetter("w");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            EnterLetter("x");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            EnterLetter("y");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            EnterLetter("z");
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Delete();
        }
    }

    public void EnterLetter(string letterPressed)
    {
        Debug.Log("Pressed the letter: " + letterPressed);
        //gameManager.poemManagers[poemNumber].lines[currentLine].viewer.letterTiles[position].Fill(letterPressed);
    }

    public void Delete()
    {
        Debug.Log("Deleting letter");
        //gameManager.poemManagers[poemNumber].lines[currentLine].viewer.letterTiles[position].Delete();
    }
}
