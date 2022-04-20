using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathController : MonoBehaviour
{
    private MenuManger menuManager;
    private void Start()
    {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManger>();
    }
    public static void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RetryScene()
    {
        SceneManager.LoadScene("Level 1");
        LoadDeathScreen(false);
    }

    public void LoadDeathScreen(bool state)
    {
        menuManager.GetFrameMainMenu().gameObject.SetActive(state);
    }

}
