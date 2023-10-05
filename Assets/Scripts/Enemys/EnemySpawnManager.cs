using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public CivilianSpawn civilSpawn;
    public GameObject[] enemyCharachters;
    public GameObject[] spawnPoints;  
    void Start()
    {

        InvokeRepeating("EnemySpawn", 15f, 5f);        
    }
    void EnemySpawn()
    {
        Instantiate(enemyCharachters[Random.Range(0, enemyCharachters.Length)], spawnPoints[civilSpawn.actualSpawnPoint].transform.position, spawnPoints[civilSpawn.actualSpawnPoint].transform.rotation);
    }





}
