using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    /* Fades canvas group in/out over a specified time */
    public IEnumerator Fade(float start, float end, float duration)
    {
        float timeElapsed = 0f;
        while (timeElapsed < duration)
        {
            timeElapsed += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(start, end, timeElapsed / duration);
            yield return null;
        }
    }
}
