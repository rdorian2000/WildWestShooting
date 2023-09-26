using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySkinSystem : MonoBehaviour
{
    public Material[] enemyMaterials;
    public GameObject enemyCharachter;
    // Start is called before the first frame update
    void Start()
    {
        enemyCharachter.GetComponent<SkinnedMeshRenderer>().material = enemyMaterials[Random.Range(0,enemyMaterials.Length)];     
    }

}
