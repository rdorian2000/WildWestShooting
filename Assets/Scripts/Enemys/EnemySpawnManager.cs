using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyCharachters;
    public GameObject[] spawnPoints;

    public GameObject pianoManCharachter;
    public GameObject pianoManSpawnPoint;

    private int actualSpawnPoint;

    
    void Start()
    {
        InvokeRepeating("EnemySpawn", 15f, 15f);
    }

    private void Update()
    {
        actualSpawnPoint = Random.Range(0,spawnPoints.Length);     
    }
    void EnemySpawn()
    {
        Instantiate(enemyCharachters[Random.Range(0, enemyCharachters.Length)], spawnPoints[actualSpawnPoint].transform.position, spawnPoints[actualSpawnPoint].transform.rotation);
        Debug.Log(spawnPoints[actualSpawnPoint]);
    }

    public IEnumerable PianoManSpawn()
    {
        yield return new WaitForSeconds(Random.Range(120, 240));

        Instantiate(pianoManCharachter, pianoManSpawnPoint.transform.position, pianoManSpawnPoint.transform.rotation);
        Debug.Log(pianoManSpawnPoint);
    }



}
