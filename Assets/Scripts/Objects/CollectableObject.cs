using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObject : MonoBehaviour, ICollectable
{
    private void OnMouseOver()
    {
        
    }

    public void Collect()
    {
        Debug.Log(name + " collected");
    }
}
