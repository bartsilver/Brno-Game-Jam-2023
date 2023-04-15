using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cupboard : MonoBehaviour
{
    [SerializeField] GameObject doorsClosed;
    [SerializeField] GameObject doorsOpen;

    public void OpenDoor()
    {
        doorsClosed.SetActive(false);
        GetComponent<Collider>().enabled = false;
        doorsOpen.SetActive(true);
    }
}
