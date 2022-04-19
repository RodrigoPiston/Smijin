using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowEnemyGenerator : GeneratorController
{
    private int cantMaxEnemies = 1;
    [SerializeField] private GameObject enemyPrefab;
    

    // Update is called once per frame
    void Start()
    { 
        SpawnEnemy(enemyPrefab);
    }


    public override void SpawnEnemy(GameObject enemyPrefab) 
    {
        base.SpawnEnemy(enemyPrefab);
    }
}
