using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundArtViewer : MonoBehaviour
{
    public Image[] poemLinePuzzleBackgrounds; // 1920x1080 backgrounds that appear when solving poem line puzzles
    public Image[] triptychPanels; // 620x1080 triptych panels that fade in left-to-right when the full poem is revealed

    /* Show the background image for the first poem line puzzle and hide the full poem state's triptych panels, set everything else to transparent */
    public void Initialize()
    {
        foreach (Image background in poemLinePuzzleBackgrounds)
        {
            background.GetComponent<CanvasGroup>().alpha = 0;
        }
        foreach (Image panel in triptychPanels)
        {
            panel.GetComponent<CanvasGroup>().alpha = 0;
        }
        poemLinePuzzleBackgrounds[0].GetComponent<CanvasGroup>().alpha = 1;
    }

    /* Hide the poem line puzzle backgrounds and fade in the triptych panels from left to right */
    public IEnumerator DisplayTriptych(float WaitTime)
    {
        foreach (Image background in poemLinePuzzleBackgrounds)
        {
            background.enabled = false;
        }
        foreach (Image panel in triptychPanels)
        {
            StartCoroutine(panel.GetComponent<UIFader>().Fade(0, 1, 1.5f));
            yield return new WaitForSeconds(1.5f);
        }
    }
}
