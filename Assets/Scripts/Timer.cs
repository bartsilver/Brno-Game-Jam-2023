using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timePerStage;


    public float elapsedTime = 0f;

    public event Action OnTimer;

    private void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >=  timePerStage)
        {
            OnTimer();
            elapsedTime = 0f;
        }
    }
}
