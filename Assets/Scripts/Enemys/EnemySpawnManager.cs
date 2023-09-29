using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public GameObject[] enemyCharachters;
    public GameObject enemyTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EnemySpawn();
    }

    void EnemySpawn()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(enemyCharachters[Random.Range(0, enemyCharachters.Length)], enemyTest.transform.position + new Vector3(0, 0, 2), enemyTest.transform.rotation);
        }
    }



}
