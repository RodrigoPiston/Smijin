using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private MenuManger menuManager;
    private void Start() {
        menuManager = GameObject.Find("MenuManager").GetComponent<MenuManger>();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene("Example_Night");
    }

    public void LoadOptions(){
        menuManager.GetFrameMainMenu().gameObject.SetActive(false);
        menuManager.GetFrameOptions().gameObject.SetActive(true);
    }
    
    public void LoadMainMenu(){
        menuManager.GetFrameMainMenu().gameObject.SetActive(true);
        menuManager.GetFrameOptions().gameObject.SetActive(false);
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
