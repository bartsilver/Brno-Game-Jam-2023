using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject equipedObject = null;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckWhatWasHit();

        }
    }

    private static Ray GetMouseRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    private void CheckWhatWasHit()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetMouseRay());
        foreach (RaycastHit hit in hits)
        {
            ICollectable collectable = hit.transform.GetComponent<ICollectable>();

            if (collectable != null)
            {
                collectable.Collect();
            }
        }
    }

    private void UseObject()
    {

    }
}
