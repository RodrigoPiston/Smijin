using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorController : MonoBehaviour
{
    enum Difficulty { Easy, Normal, Hard };

    // Start is called before the first frame update
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] Difficulty dificultad;
    private GameObject newParentObject; 

    void Start()
    {
        newParentObject = GameObject.Find("Enemies");

        switch (dificultad)
        {
            case Difficulty.Easy:
                InvokeRepeating("SpawnEnemy", spawnDelay + 3f, spawnInterval + 3f);
                break;
            case Difficulty.Normal:
                InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
                break;
            case Difficulty.Hard:
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
        GameObject enemy = Instantiate(enemyPrefabs[enemyIndex], transform.position, enemyPrefabs[enemyIndex].transform.rotation);
        if (newParentObject != null)
        {
            enemy.transform.parent = newParentObject.transform;
        }
    }
}
