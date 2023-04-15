using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour
{
    [SerializeField] GameObject controlsMenu;
    [SerializeField] GameObject mainMenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowControls()
    {
        mainMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void backToMenu()
    {
        controlsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
