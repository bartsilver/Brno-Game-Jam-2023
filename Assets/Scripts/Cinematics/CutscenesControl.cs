using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutscenesControl : MonoBehaviour
{
    public GameObject winLoseMenu;

    private void Start()
    {
        GetComponent<PlayableDirector>().played += DisableControl;
        GetComponent<PlayableDirector>().stopped += EnableControl;
    }

    private void EnableControl(PlayableDirector obj)
    {
        Debug.Log("Stop");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void DisableControl(PlayableDirector obj)
    {
        Debug.Log("Played");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
