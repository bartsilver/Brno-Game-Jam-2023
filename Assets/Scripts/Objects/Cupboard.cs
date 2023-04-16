using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour
{
    private bool isHouseCam = true;

    public bool objectCollected = true;
    public bool isOpened = false;

    private CameraControl cameraControl;

    [SerializeField] GameObject doorsClosed;
    [SerializeField] GameObject doorsOpen;
    [SerializeField] GameObject objectPlaceholder;

    private void Start()
    {
        cameraControl = FindObjectOfType<CameraControl>();
        cameraControl.OnHouseView += DisableCollider;
        cameraControl.OnHouseView += IsHouseCam;
        cameraControl.OnRoomView += EnableCollider;
        cameraControl.OnRoomView += IsNotHouseCam;
    }
    private void Update()
    {
        if (CheckIfBlendingAndHouseCam())
        {
            DisableCollider();
        }
        else
        {
            EnableCollider();
        }

        DeletePlaceholder();
    }

    private void DeletePlaceholder()
    {
        if (objectPlaceholder != null && objectCollected)
        {
            Destroy(objectPlaceholder);
        }
    }

    private bool CheckIfBlendingAndHouseCam()
    {
        return Camera.main.GetComponent<CinemachineBrain>().IsBlending || isHouseCam;
    }

    public void OpenCloseDoor()
    {
        if (!isOpened)
        {
            OpenDoor();
            return;
        }

        if (isOpened && objectCollected)
        {
            CloseDoor();
        }
    }
    public void OpenDoor()
    {
        isOpened = true;
        doorsClosed.SetActive(false);
        doorsOpen.SetActive(true);

        foreach (CollectableObject collectable in GetComponentsInChildren<CollectableObject>())
        {
            collectable.isHouseCam = false;
        }
    }

    public void CloseDoor()
    {
        isOpened = false;
        doorsClosed.SetActive(true);
        //DisableCollider();
        doorsOpen.SetActive(false);
        /*
        foreach (CollectableObject collectable in GetComponentsInChildren<CollectableObject>())
        {
            collectable.isHouseCam = false;
        }*/
    }

    private void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }

    private void IsHouseCam()
    {
        isHouseCam = true;
    }

    private void IsNotHouseCam()
    {
        isHouseCam = false;
    }
}
