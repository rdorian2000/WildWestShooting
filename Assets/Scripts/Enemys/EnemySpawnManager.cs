using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyCharachters;
    public GameObject spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemySpawn", 30f, 15f);
    }

    void EnemySpawn()
    {
        Instantiate(enemyCharachters[Random.Range(0, enemyCharachters.Length)], spawnPoint.transform.position + new Vector3(0, 0, 2), spawnPoint.transform.rotation);
    }



}
