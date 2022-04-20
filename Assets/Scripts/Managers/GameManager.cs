using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public int partsObtained, lastSP;

    public bool evento1, evento2, evento3;
    public int enemiesRequired = 10; 
    public int enemiesKilled = 0;

    [SerializeField] GameObject boss;

    private void Awake()
    {
        if (instancia == null) 
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
            partsObtained = 0;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Evento1()
    {
        if (!evento1)
        {
            evento1 = true;
        }
    }

    public void Evento2()
    {
        if (!evento2)
        {
            evento2 = true;
        }
    }

    // -- evento 3
    public void EnemiesKilled()
    {
        enemiesKilled++;
        if (enemiesKilled>=enemiesRequired)
        {
            evento3 = true;

            if (evento1 && evento2 && evento3)
            {
                boss.gameObject.SetActive(true);
            }
        }

    }

}
