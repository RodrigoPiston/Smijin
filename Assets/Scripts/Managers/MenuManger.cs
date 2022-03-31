using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuManger : MonoBehaviour
{
    [SerializeField] private CinemachineBrain cinemachineBrain; 
    [SerializeField] private CinemachineVirtualCamera frame0_cam;
    [SerializeField] private CinemachineVirtualCamera frame1_cam;
    [SerializeField] private GameObject frameMainMenu;
    [SerializeField] private GameObject frameOptions;
    [SerializeField] private GameObject frameWaitScreen;
    [SerializeField] private GameObject startButton;
    [SerializeField] private EventSystem ES;

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && frameWaitScreen.activeInHierarchy)
        {
            frameWaitScreen.SetActive(false);
            frameMainMenu.SetActive(true);
            ES.SetSelectedGameObject(startButton);
            frame0_cam.gameObject.SetActive(false);
            frame1_cam.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !frameWaitScreen.activeInHierarchy)
        {
            frameMainMenu.SetActive(false);
            frameWaitScreen.SetActive(true);
            frame1_cam.gameObject.SetActive(false);           
            frame0_cam.gameObject.SetActive(true); 
        }

        
        if(Input.GetKeyDown(KeyCode.Escape)){
            frameWaitScreen.SetActive(false);

            if(frameOptions.activeInHierarchy){
                frameOptions.SetActive(false);
                frameMainMenu.SetActive(true);
            }else{
                frameOptions.SetActive(true);
                frameMainMenu.SetActive(false);
            }        
        }
    }

    public GameObject GetFrameMainMenu(){
        return frameMainMenu;
    }
    
    public GameObject GetFrameOptions(){
        return frameOptions;
    }
    
    public GameObject GetFrameWaitScreen(){
        return frameWaitScreen;
    }
}
