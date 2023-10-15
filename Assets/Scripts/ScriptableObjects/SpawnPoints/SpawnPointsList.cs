using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpawnPointsList", menuName = "Script/ScriptableObjects/SpawnPoints")]
public class SpawnPointsList : ScriptableObject
{
    public GameObject[] spawnPoints;
}

