using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFader : MonoBehaviour
{
    public CanvasGroup canvasGroup;

    void Start()
    {
        StartCoroutine(Fade(1, 0, 0.8f));
    }

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
