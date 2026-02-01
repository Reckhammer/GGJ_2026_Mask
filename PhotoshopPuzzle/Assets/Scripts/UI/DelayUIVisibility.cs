using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DelayUIVisibility : MonoBehaviour
{
    public float initialDelay = 0.5f;
    public float fadeInTime = 3f;
    private CanvasGroup myImage;

    public void Awake()
    {
        myImage = GetComponent<CanvasGroup>();
    }

    public void Start()
    {
        StartFadeInCoroutine();
    }

    public void StartFadeInCoroutine()
    {
        myImage.alpha = 0f;
        StartCoroutine(FadeInCoroutine());
    }

    private IEnumerator FadeInCoroutine()
    {
        yield return new WaitForSeconds(initialDelay);

        float currentTime = 0f;

        while (myImage.alpha< 1f)
        {
            myImage.alpha = Mathf.Lerp(0f, 1f, currentTime / fadeInTime);
            currentTime += Time.deltaTime;
            
            yield return null;
        }

        myImage.alpha = 1f;
    }
}
