using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class CameraControl : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera[] camerasArray;

    public event Action OnHouseView;
    public event Action OnRoomView;

    private void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            SwitchCamera("House Cam");
            OnHouseView();
        }
    }

    public void SwitchCamera(string cameraName)
    {
        foreach (CinemachineVirtualCamera camera in camerasArray)
        {
            if (camera.name == cameraName)
            {
                if(camera.name != "House Cam")
                {
                    OnRoomView();
                }
                camera.Priority = 100;
            }
            else
            {
                camera.Priority = 0;
            }
        }
    }
}
