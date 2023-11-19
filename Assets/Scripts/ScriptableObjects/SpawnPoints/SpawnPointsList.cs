using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SpawnPointsList", menuName = "Script/ScriptableObjects/SpawnPoints")]
//Navmesh agent spawnpoint list.
public class SpawnPointsList : ScriptableObject
{
    public GameObject[] spawnPoints;
}

