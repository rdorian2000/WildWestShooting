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
        StartCoroutine(EnemySpawn());
        StartCoroutine(spawnpointRandomizer());
    }
  
    public IEnumerator spawnpointRandomizer()
    {
        for(; ; )
        {
            actualSpawnPoint = Random.Range(0, spawnPointList.spawnPoints.Length);
            yield return new WaitForSeconds(1);
        }
                 
    }


    public IEnumerator EnemySpawn()
    {      
        for(; ; )
        {
            Instantiate(enemyCharachters[Random.Range(0, enemyCharachters.Length)], spawnPointList.spawnPoints[actualSpawnPoint].transform.position, spawnPointList.spawnPoints[actualSpawnPoint].transform.rotation);
            Debug.Log(spawnPointList.spawnPoints[actualSpawnPoint]);
            yield return new WaitForSeconds(Random.Range(10, 15));
        }                   
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
