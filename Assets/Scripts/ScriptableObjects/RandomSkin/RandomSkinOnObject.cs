using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSkinOnObject : MonoBehaviour
{
    [SerializeField] private SkinMaterials skinMat;

    public GameObject enemyCharachter;
    //Add random skin on the npc-s.
    void Start()
    {
        enemyCharachter.GetComponent<SkinnedMeshRenderer>().material = skinMat.skinMaterials[Random.Range(0, skinMat.skinMaterials.Length)];
    }

}
