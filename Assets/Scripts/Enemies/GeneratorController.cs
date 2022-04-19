using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GeneratorController : MonoBehaviour
{
    enum Dificultades { Easy, Normal, Hard };

    // Start is called before the first frame update
    //[SerializeField] GameObject enemyPrefabs;
    [SerializeField] float spawnInterval = 2f;
    [SerializeField] float spawnDelay = 2f;
    [SerializeField] Dificultades dificultad;
    [SerializeField] string wayPointContainerName;

    void Start()
    {
        //SpawnEnemy();
        //InvokeRepeating("SpawnEnemy",spawnDelay,spawnInterval);
    }

    public string GetWayPointName()
    {
        return wayPointContainerName;
    }

    public virtual void SpawnEnemy(GameObject enemyPrefab)
    {

        //switch (dificultad)
        //{
        //    case Dificultades.Easy:
        //        InvokeRepeating("SpawnEnemy", spawnDelay + 3f, spawnInterval + 3f);
        //        break;
        //    case Dificultades.Normal:
        //        InvokeRepeating("SpawnEnemy", spawnDelay, spawnInterval);
        //        break;
        //    case Dificultades.Hard:
        //        InvokeRepeating("SpawnEnemy", spawnDelay - 1f, spawnInterval - 1f);
        //        break;
        //    default:
        //        Debug.Log("ERROR DIFICULTAD NO VALIDA");
        //        break;
        //}

        //int enemyIndex = Random.Range(0, enemyPrefabs.Length); 
        Instantiate(enemyPrefab, transform); 
        //Instantiate(enemyPrefabs, transform.position, enemyPrefabs.transform.rotation);
    }

}
