using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundArtViewer : MonoBehaviour
{
    public Image singlePanel;
    public GameObject triptychPanelSet;
    public Image[] triptychPanels;

    void Start()
    {
        SetUpSinglePanel();   
    }

    // TODO: Later on, soften this up with some fading effects

    public void SetUpSinglePanel()
    {
        singlePanel.enabled = true;
        // TODO: Set image sprite to this poem's artwork
        triptychPanelSet.SetActive(false);
    }

    public IEnumerator DisplayTriptych(float WaitTime)
    {
        singlePanel.enabled = true;
        triptychPanelSet.SetActive(true);
        // TODO: Set image sprites to this poem's artwork
        yield return new WaitForSeconds(WaitTime);
    }
}
