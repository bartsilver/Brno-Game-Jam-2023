using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Playables;

public class Prisoner : MonoBehaviour
{
    [SerializeField] float maxNoiseLevel = 0f;

    [SerializeField] GameObject badVignette;
    [SerializeField] GameObject neutralVignette;
    [SerializeField] GameObject goodVignette;

    private PlayableDirector vignettePD;


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

        if(noise < 0)
        {
            goodVignette.SetActive(true);
            vignettePD = goodVignette.GetComponent<PlayableDirector>();
        }
        if (noise == 0)
        {
            neutralVignette.SetActive(true);
            vignettePD = neutralVignette.GetComponent<PlayableDirector>();
        }
        if (noise > 0)
        {
            badVignette.SetActive(true);
            vignettePD = badVignette.GetComponent<PlayableDirector>();
        }

        vignettePD.stopped += DisableVignette;
    }

    private void DisableVignette(PlayableDirector obj)
    {
        vignettePD.gameObject.SetActive(false);
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
