using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    [SerializeField] UsableObject usableObject;

    private PlayerControl player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
    }
    public void EquipSelectedObject()
    {
        player.equipedObject = usableObject;
    }

}
