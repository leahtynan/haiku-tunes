using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoemManager : MonoBehaviour
{
    // References
    public PoemLineViewer[] lines;

    // Poem content
    public string[] haiku;
    public AudioClip[] musicalPhrases;
    public AudioClip fullSong;

    public void ShowPoem()
    {
        // TODO:
        // Hide the input UI for the third line
        // Show the haiku
        // Play the full song, looping indefinitely
        // Provide UI to proceed to next poem
    }

}
