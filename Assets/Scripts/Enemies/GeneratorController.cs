using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    enum Dificultades { Easy, Normal, Hard };

    // Start is called before the first frame update
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] Dificultades dificultad;
    void Start()
    {
        //SpawnEnemy();
        //InvokeRepeating("SpawnEnemy",spawnDelay,spawnInterval); 
        switch (dificultad)
        {
            case Dificultades.Easy:
                Debug.Log("FACIL");
                InvokeRepeating("SpawnEnemy", spawnDelay + 3f, spawnInterval + 3f);
                break;
            case Dificultades.Normal:
                Debug.Log("MEDIO");
                InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
                break;
            case Dificultades.Hard:
                Debug.Log("DIFICIL");
                InvokeRepeating("SpawnEnemy", spawnDelay - 1f, spawnInterval - 1f);
                break;
            default:
                Debug.Log("ERROR DIFICULTAD NO VALIDA");
                break;
        }

    }
    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        //Instantiate(enemyPrefab, transform);
        Instantiate(enemyPrefabs[enemyIndex], transform.position, enemyPrefabs[enemyIndex].transform.rotation);
    }
}
