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

    private EnemyMoveForward enemyMoveFor;
    private Rigidbody rb;
    private BoxCollider boxColl;
    public int shootNumberForKill;
    
    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        boxColl = GetComponent<BoxCollider>();
        enemyMoveFor=GetComponent<EnemyMoveForward>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        bloodDrop.Stop();
        shootNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
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

    void Death()
    {
        if (shootNumber > shootNumberForKill)
        {

            enemyMoveFor.isDeath = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            boxColl.enabled = false;
            Invoke("LeavingTheMap", 10f);
        }

    }

    void LeavingTheMap()
    {
        rb.useGravity = true;

        if (transform.position.y < -2)
        {
            Destroy(gameObject);
        }
    }


}
