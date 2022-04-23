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
    public Text feedback;

    void Start()
    {
        Toggle(false);
        for(int i = 0; i < haikuLines.Length; i++)
        {
            haikuLines[i].text = fullText[i];
            haikuLines[i].GetComponent<CanvasGroup>().alpha = 0;
        }
        feedback.text = "";
    }

    /* Hides/shows entire haiku game oject */
    public void Toggle(bool isShowing)
    {
        haiku.SetActive(isShowing);
    }

    /* Reveals the haiku by revealing the text line-by-line */
    public IEnumerator RevealPoem(float WaitTime)
    {
        Toggle(true);
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(haikuLines[i].GetComponent<UIFader>().Fade(0, 1, WaitTime));
            yield return new WaitForSeconds(WaitTime);
        }
    }

    /* Types out the line of the haiku letter-by-letter; this functionality is currently un-used */
    public IEnumerator TypeLine(int lineNumber)
    {
        for(int i = 0; i < fullText[lineNumber].Length; i++)
        {
            currentText[lineNumber] = fullText[lineNumber].Substring(0, i);
            haikuLines[lineNumber].text = currentText[lineNumber];
            yield return new WaitForSeconds(delay);
        }
    }

    /* Types out all three lines of the haiku letter-by-letter; this functionality is currently un-used */
    public IEnumerator TypePoem()
    {
        for(int i = 0; i < 3; i++)
        {
            StartCoroutine(TypeLine(i));
            yield return new WaitForSeconds(delay * fullText[i].Length);
        }
    }

}
