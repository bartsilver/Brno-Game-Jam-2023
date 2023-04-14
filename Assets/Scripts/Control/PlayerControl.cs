using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public UsableObject equipedObject = null;

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
            Prisoner prisoner = hit.transform.GetComponent<Prisoner>();

            if (collectable != null)
            {
                collectable.Collect();
            }

            if (prisoner != null && equipedObject != null)
            {
                equipedObject.UseObject(prisoner);
                GameObject.FindWithTag("Inventory").GetComponent<InventoryUI>().TakeFromInventory(equipedObject.name);
                equipedObject = null;
            }
        }
    }
}
