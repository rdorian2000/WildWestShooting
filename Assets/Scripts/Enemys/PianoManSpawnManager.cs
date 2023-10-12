using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoManSpawnManager : MonoBehaviour
{
    public GameObject pianoManCharachter;
    public GameObject spawnPoint;

    public bool pianoManisDead;

    void Start()
    {
        pianoManisDead = false;

    }

    private void Update()
    {
        if (pianoManisDead)
        {
            PianoManSpawn();
            pianoManisDead = false;
        }


    }
    void PianoManSpawn()
    {
        
        Instantiate(pianoManCharachter, spawnPoint.transform.position, spawnPoint.transform.rotation);
        Debug.Log(spawnPoint);
        
    }
}
