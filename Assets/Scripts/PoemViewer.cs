using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemViewer : MonoBehaviour
{
    public GameObject haiku;
    public Text[] haikuLines;
    private float delay = 0.1f;
    public string[] fullText;
    public string[] currentText;

    void Start()
    {
        Toggle(false);
    }

    public void Toggle(bool isShowing)
    {
        haiku.SetActive(isShowing);
    }

    public IEnumerator TypeLine(int lineNumber)
    {
        for(int i = 0; i < fullText[lineNumber].Length; i++)
        {
            currentText[lineNumber] = fullText[lineNumber].Substring(0, i);
            haikuLines[lineNumber].text = currentText[lineNumber];
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator TypePoem()
    {
        for(int i = 0; i < 3; i++)
        {
            StartCoroutine(TypeLine(i));
            yield return new WaitForSeconds(delay * fullText[i].Length);
        }
    }

}
