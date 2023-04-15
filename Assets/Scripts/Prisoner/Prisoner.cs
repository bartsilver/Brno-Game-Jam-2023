using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Prisoner : MonoBehaviour
{
    [SerializeField] float maxNoiseLevel = 0f;

    private float noiseLevel = 0f;
    public float noiseLevelPercentage = 0f;

    public int stage = 1;

    CameraControl cameraControl;

    public event Action OnLose;
    public event Action OnWin;

    private void Start()
    {
        cameraControl = FindObjectOfType<CameraControl>();
        FindObjectOfType<Timer>().OnTimer += UpdateStage;
        cameraControl.OnHouseView += DisableCollider;
        cameraControl.OnRoomView += EnableCollider;
    }

    private void Update()
    {
        if (Cursor.visible == false) return;
        noiseLevel += Time.deltaTime;
        noiseLevelPercentage = (noiseLevel / maxNoiseLevel) * 100f;
        if (noiseLevelPercentage > 100)
        {
            LoseGame();
        }
    }


    public void UpdateStats(float noise)
    {
        noiseLevel = Mathf.Max(noiseLevel + noise, 0);
        Debug.Log("object used");
    }

    public int GetStage()
    {
        return stage;
    }

    private void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
    private void UpdateStage()
    {
        if (stage == 3)
        {
            WinGame();
            return;
        }
        stage += 1;
    }

    private void WinGame()
    {
        OnWin();
        this.enabled = false;
    }
    private void LoseGame()
    {
        Debug.Log("Lost game!");
        OnLose();
        this.enabled = false;
    }
}
