using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundArtViewer : MonoBehaviour
{
    public Image[] poemLinePuzzleBackgrounds; // 1920x1080 backgrounds that appear when solving poem line puzzles
    public Image[] triptychPanels; // 620x1080 triptych panels that fade in left-to-right when the full poem is revealed

    public void Initialize()
    {
        // Show the background image for the first poem line puzzle 
        foreach (Image background in poemLinePuzzleBackgrounds)
        {
            background.enabled = false;
        }
        poemLinePuzzleBackgrounds[0].enabled = true;
        // Hide the full poem state's triptych panels
        foreach (Image panel in triptychPanels)
        {
            panel.enabled = false;
        }
    }

    public IEnumerator DisplayTriptych(float WaitTime)
    {
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
