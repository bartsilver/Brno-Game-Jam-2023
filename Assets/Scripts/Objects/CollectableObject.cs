using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class CollectableObject : MonoBehaviour, ICollectable
{
    private GameObject inventory;
    private CameraControl cameraControl;

    private Vector3 startingPosition;
    private float shakeTime = 0.2f;
    private bool shouldShake = false;
    private bool isHouseCam = true;
    float elapsedTime = 0f;

    private void Start()
    {
        startingPosition = transform.position;
        cameraControl = FindObjectOfType<CameraControl>();
        inventory = GameObject.FindWithTag("Inventory");
        cameraControl.OnHouseView += DisableCollider;
        cameraControl.OnHouseView += IsHouseCam;
        cameraControl.OnRoomView += EnableCollider;
        cameraControl.OnRoomView += IsNotHouseCam;

        GetComponent<PlayableDirector>().stopped += PutInInventory;
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

        if(shouldShake)
        {
            if (elapsedTime < shakeTime)
            {              
                transform.position = new Vector3(startingPosition.x + Random.Range(-0.15f, 0.15f), startingPosition.y + 0f, startingPosition.z + 0f);
                elapsedTime += Time.deltaTime;
            }
            else if (elapsedTime >= shakeTime)
            {
                transform.position = startingPosition;
                shouldShake = false;
            }
        }
    }
    public void Collect()
    {
        Debug.Log(name + " collected");
        GetComponent<PlayableDirector>().Play();
        cameraControl.OnHouseView -= DisableCollider;
        cameraControl.OnRoomView -= EnableCollider;
    }

    private void PutInInventory(PlayableDirector obj)
    {
        inventory.GetComponent<InventoryUI>().PutInInventory(gameObject.name);
        GetComponent<Animation>().Play();

        Destroy(gameObject);
    }

    private void IsHouseCam()
    {
        isHouseCam = true;
    }

    private void IsNotHouseCam()
    {
        isHouseCam = false;
    }

    private void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
    private void OnMouseEnter()
    {
        if (GetComponent<Collider>().enabled == true)
        {
            shouldShake = true;
            elapsedTime = 0f;
        }
    }

    private void OnMouseExit()
    {
        shouldShake = false;
        transform.position = startingPosition;
    }

}
