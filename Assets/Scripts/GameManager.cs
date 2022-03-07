using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PoemManager[] poemManagers;
    private int currentPoem;
    private int numberCluesSolved;

    void Start()
    {
        LoadPoem(0);
    }  

    public void LoadPoem(int poemNumber)
    {
        Debug.Log("Loading poem: " + currentPoem);
        numberCluesSolved = 0;
        //Show first line of the poem, i.e.poemManagers[currentPoem].ShowLine(0)
    }
}
