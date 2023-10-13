using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyKillControll : MonoBehaviour
{
    private CharacterController characterController;
    private EnemyHealPoints enemyHeal;
    public GameObject enemyCharacter;
    public GameObject enemyHealBar;

    private NavMeshPatrolling NMPatrol;
    private Rigidbody rb;
    private BoxCollider boxColl;

    
    // Start is called before the first frame update
    void Start()
    {
        enemyHealBar.SetActive(true);
        enemyHeal = GetComponent<EnemyHealPoints>();
        characterController = GameObject.Find("Player").GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        boxColl = GetComponent<BoxCollider>();
        NMPatrol = GetComponent<NavMeshPatrolling>();

    }

    // Update is called once per frame
    void Update()
    {
        Death();
        DestroyWhenLeaveTheMap();
    }


    void Death()
    {
        if (enemyHeal.actualHP <= 0)
        {
            enemyHealBar.SetActive(false);
            NMPatrol.isDeath = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            boxColl.enabled = false;
            Invoke("LeavingTheMap", 10f);
        }

    }

    void LeavingTheMap()
    {              
        gameObject.GetComponent<NavMeshAgent>().enabled = false;
        rb.useGravity = true;
        if (transform.position.y < -2)
        {
            
            Destroy(gameObject);
        }
    }

    void DestroyWhenLeaveTheMap()
    {
        if (characterController.backward)
        {
            if(transform.position.z > (-1)) 
            {
                Destroy(gameObject);
            }
        }
    }

}
