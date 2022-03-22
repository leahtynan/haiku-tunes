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
            gameManager.EnterLetter("a");
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            gameManager.EnterLetter("b");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            gameManager.EnterLetter("c");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameManager.EnterLetter("d");
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            gameManager.EnterLetter("e");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            gameManager.EnterLetter("f");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            gameManager.EnterLetter("g");
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            gameManager.EnterLetter("h");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameManager.EnterLetter("i");
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            gameManager.EnterLetter("j");
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameManager.EnterLetter("k");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            gameManager.EnterLetter("l");
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            gameManager.EnterLetter("m");
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            gameManager.EnterLetter("n");
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            gameManager.EnterLetter("o");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            gameManager.EnterLetter("p");
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameManager.EnterLetter("q");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameManager.EnterLetter("r");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameManager.EnterLetter("s");
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            gameManager.EnterLetter("t");
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            gameManager.EnterLetter("u");
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            gameManager.EnterLetter("v");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameManager.EnterLetter("w");
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            gameManager.EnterLetter("x");
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            gameManager.EnterLetter("y");
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            gameManager.EnterLetter("z");
        }
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            gameManager.Delete();
        }
    }

}
