using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    

    public GameObject[] enemyCharachters;
    [SerializeField] private SpawnPointsList spawnPointList;

    public GameObject pianoManCharachter;
    public GameObject pianoManSpawnPoint;

    private int actualSpawnPoint;

    void OnEnable()
    {
        EnemyHealPoints.Spawn += PianoManSpawn;
    }

    void OnDisable()
    {
        EnemyHealPoints.Spawn -= PianoManSpawn;
    }

    void Start()
    {
        InvokeRepeating("EnemySpawn", 15f, 15f);
    }

    private void Update()
    {
        actualSpawnPoint = Random.Range(0, spawnPointList.spawnPoints.Length);  
    }
    public void EnemySpawn()
    {
        //yield return new WaitForSeconds(Random.Range(15, 20));

        Instantiate(enemyCharachters[Random.Range(0, enemyCharachters.Length)], spawnPointList.spawnPoints[actualSpawnPoint].transform.position, spawnPointList.spawnPoints[actualSpawnPoint].transform.rotation);
        Debug.Log(spawnPointList.spawnPoints[actualSpawnPoint]);
    }

    public IEnumerator PianoManInstantiate()
    {
        
        yield return new WaitForSeconds(Random.Range(120, 240));

        Instantiate(pianoManCharachter, pianoManSpawnPoint.transform.position, pianoManSpawnPoint.transform.rotation);
        OnEnable();
    }

    

    public void PianoManSpawn()
    {
        StartCoroutine(PianoManInstantiate());
        OnDisable();
    }





}
