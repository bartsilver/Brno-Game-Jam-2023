using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour
{
    private bool isHouseCam = true;
    private CameraControl cameraControl;

    [SerializeField] GameObject doorsClosed;
    [SerializeField] GameObject doorsOpen;

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
        if (Camera.main.GetComponent<CinemachineBrain>().IsBlending || isHouseCam)
        {
            DisableCollider();
        }
        else
        {
            EnableCollider();
        }
    }
    public void OpenDoor()
    {
        doorsClosed.SetActive(false);
        DisableCollider();
        doorsOpen.SetActive(true);

        foreach (CollectableObject collectable in GetComponentsInChildren<CollectableObject>())
        {
            collectable.isHouseCam = false;
        }
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
