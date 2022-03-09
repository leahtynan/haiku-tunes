using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoemViewer : MonoBehaviour
{
    public Text haiku;

    void Start()
    {
        Toggle(false);
    }

    public void Toggle(bool isShowing)
    {
        haiku.enabled = isShowing;
    }

}
