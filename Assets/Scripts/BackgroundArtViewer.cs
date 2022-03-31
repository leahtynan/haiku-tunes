using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundArtViewer : MonoBehaviour
{
    public Image[] poemLinePuzzleBackgrounds; // 1920x1080 backgrounds that appear when solving poem line puzzles
    public Image[] triptychPanels; // 620x1080 triptych panels that fade in left-to-right when the full poem is revealed

    /* Show the background image for the first poem line puzzle and hide the full poem state's triptych panels */
    public void Initialize()
    {
        Debug.Log("got here");
        poemLinePuzzleBackgrounds[0].GetComponent<CanvasGroup>().alpha = 1;
        foreach (Image panel in triptychPanels)
        {
            panel.enabled = false;
        }
    }

    /* Hide the poem line puzzle backgrounds and fade in the triptych panels from left to right */
    public IEnumerator DisplayTriptych(float WaitTime)
    {
        // TODO: Do fades instead
        foreach (Image background in poemLinePuzzleBackgrounds)
        {
            background.enabled = false;
        }
        foreach (Image panel in triptychPanels)
        {
            panel.enabled = true;
            yield return new WaitForSeconds(WaitTime);
        }
    }
}
