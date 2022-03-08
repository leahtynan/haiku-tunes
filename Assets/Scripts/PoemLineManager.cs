using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemLineManager : MonoBehaviour
{
    public string answer;
    // TODO: Number of letters in the answer? To give user extra clue. Also, may tie into UI like how crossword puzzles have number of visible cubes to fill.

    public bool CheckAnswer(string answerSubmitted)
    {
        bool isCorrect = false;
        if(answerSubmitted == answer)
        {
            isCorrect = true;
        }
        return isCorrect;
    }

}
