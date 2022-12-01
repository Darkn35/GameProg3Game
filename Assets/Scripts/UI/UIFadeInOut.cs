using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFadeInOut : MonoBehaviour
{
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private bool fadeIn = false;
    [SerializeField] private bool fadeOut = false;
    [SerializeField] private float fadeSpeed = 1f;

    public void ShowUI()
    {
        fadeIn = true;
        fadeOut = false;
    }

    public void HideUI()
    {
        fadeOut = true;
        fadeIn = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (fadeIn)
        {
            canvasGroup.alpha = canvasGroup.alpha + (Time.deltaTime * fadeSpeed);
            if (canvasGroup.alpha >= 1)
            {
                fadeIn = false;
            }
        }
        if (fadeOut)
        {
            canvasGroup.alpha = canvasGroup.alpha - (Time.deltaTime * fadeSpeed);
            if (canvasGroup.alpha == 0)
            {
                fadeOut = false;
            }
        }
    }
}
