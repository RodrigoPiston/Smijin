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
    [SerializeField] private GameObject[] frame;
    [SerializeField] private GameObject startButton;
    [SerializeField] private EventSystem ES;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && frame[0].activeInHierarchy)
        {
            frame[0].SetActive(false);
            frame[1].SetActive(true);
            ES.SetSelectedGameObject(startButton);
            frame0_cam.gameObject.SetActive(false);
            frame1_cam.gameObject.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !frame[0].activeInHierarchy)
        {
            frame[1].SetActive(false);
            frame[0].SetActive(true);
            frame1_cam.gameObject.SetActive(false);           
            frame0_cam.gameObject.SetActive(true); 
        }
    }


}
