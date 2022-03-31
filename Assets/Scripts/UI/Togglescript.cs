using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Togglescript : MonoBehaviour {

    Toggle toggle;

    private void Start()
    {
        toggle = GetComponent<Toggle>();
    }

    public GameObject slider;


    private void Update()
    {
        if (toggle.isOn)
        {
            slider.SetActive(false);
        }
        else
        {
            slider.SetActive(true);
        }
    }
}
