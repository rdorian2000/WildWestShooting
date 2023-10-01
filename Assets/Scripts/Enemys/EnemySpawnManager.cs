using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyCharachters;
    public GameObject[] spawnPoints;
    private int actualSpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawn", 30f, 15f);
    }

    void Update()
    {
        actualSpawnPoint = Random.Range(0, spawnPoints.Length);
    }
    void EnemySpawn()
    {
        
        Instantiate(enemyCharachters[Random.Range(0, enemyCharachters.Length)], spawnPoints[actualSpawnPoint].transform.position + new Vector3(0, 0, 2), spawnPoints[actualSpawnPoint].transform.rotation);
    }



}
