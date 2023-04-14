using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Image[] objectInInventory;

    public void PutInInventory(string name)
    {
        foreach (Image objectToCollect in objectInInventory)
        {
            if (objectToCollect.name == name)
            {
                objectToCollect.enabled = true;
            }
        }
    }

    public void TakeFromInventory(string name)
    {
        foreach (Image objectToCollect in objectInInventory)
        {
            if (objectToCollect.name == name)
            {
                objectToCollect.enabled = false;
            }
        }
    }
}
