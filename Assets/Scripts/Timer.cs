using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float timePerStage;
    [SerializeField] Image mask;

    float totalTime;
    float originalSize;

    private float totalElapsedTime = 0f;
    public float elapsedTime = 0f;

    public event Action OnTimer;

    private void Start()
    {
        originalSize = mask.rectTransform.rect.width;
        totalTime = timePerStage * 3;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        totalElapsedTime += Time.deltaTime;

        UpdateTimerBar();

        if (elapsedTime >=  timePerStage)
        {
            OnTimer();
            elapsedTime = 0f;
        }
    }

    private void UpdateTimerBar()
    {
        float percentage = (totalElapsedTime / totalTime) * 100;
        mask.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, originalSize - percentage);
    }
}
