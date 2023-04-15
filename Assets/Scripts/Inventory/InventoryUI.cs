using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] GameObject[] objectInInventory;
    private GameObject gameObjectToMove;


    private void Update()
    {
        
    }

    public void PutInInventory(string name)
    {
        foreach (GameObject objectToCollect in objectInInventory)
        {
            if (objectToCollect.name == name)
            {
                Debug.Log(name + " put in inventory");
                objectToCollect.SetActive(true);
                //objectToCollect.transform.
            }
        }
    }

    public void TakeFromInventory(string name)
    {
        foreach (GameObject objectToCollect in objectInInventory)
        {
            if (objectToCollect.name == name)
            {
                objectToCollect.SetActive(false);
            }
        }
    }
}
