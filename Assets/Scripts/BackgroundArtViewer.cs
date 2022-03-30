using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundArtViewer : MonoBehaviour
{
    public Image singlePanel;
    public Image[] triptychPanels;

    // TODO: Later on, soften this up with some fading effects

    public void SetUpSinglePanel()
    {
        singlePanel.enabled = true;
        // TODO: Set image sprite to this poem's artwork
        foreach(Image panel in triptychPanels)
        {
            panel.enabled = false;
        }
    }

    public IEnumerator DisplayTriptych(float WaitTime)
    {
        singlePanel.enabled = false;
        foreach(Image panel in triptychPanels)
        {
            // TODO: Set image sprites to this poem's artwork
            panel.enabled = true;
            yield return new WaitForSeconds(WaitTime);
        }
    }
}
