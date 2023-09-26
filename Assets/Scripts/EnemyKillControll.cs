using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillControll : MonoBehaviour
{
    public GameObject enemyCharacter;
    public GameObject bloodSpawnPoint;
    public ParticleSystem bloodDrop;
    public bool isBlooding;
    // Start is called before the first frame update
    void Start()
    {
        isBlooding = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlooding)
        {
            bloodDrop.Play();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        bloodSpawnPoint.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, bloodSpawnPoint.transform.position.z);
        isBlooding = true;
        Destroy(other.gameObject);       
    }
}
