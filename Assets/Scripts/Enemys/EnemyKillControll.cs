using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillControll : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject enemyCharacter;
    public GameObject bloodSpawnPoint;
    public ParticleSystem bloodDrop;
    [HideInInspector] public int shootNumber;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bloodDrop.Stop();
        shootNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RevolverBullet"))
        {
            gameManager.AddScore(1);
            shootNumber += 1;
            bloodSpawnPoint.transform.position = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, bloodSpawnPoint.transform.position.z);
            bloodDrop.Play();
            Destroy(other.gameObject);
        }
               
    }
}
