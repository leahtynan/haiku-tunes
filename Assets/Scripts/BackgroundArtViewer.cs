using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundArtViewer : MonoBehaviour
{
    public Image[] backgroundUI; // 1920x1080 backgrounds that appear when solving poem line puzzles
    public Image[] triptychUI; // 620x1080 triptych panels that fade in left-to-right when the full poem is revealed
    public Sprite[] backgroundArt; // Art for the background UI
    public Sprite[] triptychArt; // Art for the triptych panel UI

    /* Load art, show the background image for the first poem line puzzle and hide the full poem state's triptych panels, set everything else to transparent */
    public void Initialize()
    {
        for(int i = 0; i < 3; i++)
        {
            backgroundUI[i].GetComponent<CanvasGroup>().alpha = 0;
            triptychUI[i].GetComponent<CanvasGroup>().alpha = 0;
            backgroundUI[i].sprite = backgroundArt[i];
            triptychUI[i].sprite = triptychArt[i];
        }
        backgroundUI[0].GetComponent<CanvasGroup>().alpha = 1;
    }

    /* Hide the poem line puzzle backgrounds and fade in the triptych panels from left to right */
    public IEnumerator DisplayTriptych(float WaitTime)
    {
        foreach (Image background in backgroundUI)
        {
            background.enabled = false;
        }
        foreach (Image panel in triptychUI)
        {
            StartCoroutine(panel.GetComponent<UIFader>().Fade(0, 1, 1.5f));
            yield return new WaitForSeconds(1.5f);
        }
    }
}
