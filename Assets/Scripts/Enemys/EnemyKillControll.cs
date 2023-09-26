using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillControll : MonoBehaviour
{
    public GameObject enemyCharacter;
    public GameObject bloodSpawnPoint;
    public ParticleSystem bloodDrop;
    public int shootNumber;

    // Start is called before the first frame update
    void Start()
    {
        bloodDrop.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        shootNumber += 1;
        bloodSpawnPoint.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, bloodSpawnPoint.transform.position.z);
        bloodDrop.Play();
        Destroy(other.gameObject);       
    }
}
