using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisoner : MonoBehaviour
{
    public float noiseLevel = 0f;
    public int stage = 1;

    CameraControl cameraControl;

    private void Start()
    {
        cameraControl = FindObjectOfType<CameraControl>();
        FindObjectOfType<Timer>().OnTimer += UpdateStage;
        cameraControl.OnHouseView += DisableCollider;
        cameraControl.OnRoomView += EnableCollider;
    }

    private void Update()
    {
        noiseLevel += Time.deltaTime;
    }
    public void UpdateStats(float noise)
    {
        noiseLevel = Mathf.Max(noiseLevel + noise, 0);
        //noiseLevel += noise;
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
            //Win
            return;
        }
        stage += 1;
    }
}
