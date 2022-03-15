using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int partsObtained;
    public int lastSavePoint;

    private void Awake()
    {
        if (instancia == null) 
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            partsObtained = 0;
            lastSavePoint = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
