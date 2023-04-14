using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;
using UnityEngine.UI;

public class CameraAssign : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera assignedCamera;

    Camera mainCamera;
    CameraControl mainCamControl;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void Start()
    {
        mainCamControl = mainCamera.GetComponentInParent<CameraControl>();
        mainCamControl.OnHouseView += EnableInteraction;
    }

    public void SelectedCamera()
    {
        GetComponent<Button>().interactable = false;
        mainCamControl.SwitchCamera(assignedCamera.name);
    }

    private void EnableInteraction()
    {
        GetComponent<Button>().interactable = true;
    }
}
