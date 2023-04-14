using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableObject : MonoBehaviour, ICollectable
{
    private GameObject inventory;
    private CameraControl cameraControl;

    private void Start()
    {
        cameraControl = FindObjectOfType<CameraControl>();
        inventory = GameObject.FindWithTag("Inventory");
        cameraControl.OnHouseView += DisableCollider;
        cameraControl.OnRoomView += EnableCollider;
    }
    public void Collect()
    {
        Debug.Log(name + " collected");
        inventory.GetComponent<InventoryUI>().PutInInventory(gameObject.name);
    }

    private void EnableCollider()
    {
        GetComponent<Collider>().enabled = true;
    }

    private void DisableCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
    private void OnMouseOver()
    {
        
    }

}
