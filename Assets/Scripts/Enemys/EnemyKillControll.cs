using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyKillControll : MonoBehaviour
{
    private CharacterController characterController;
    private EnemyHealPoints enemyHeal;
    public GameObject enemyCharacter;

    private NavMeshPatrolling NMPatrol;
    private Rigidbody rb;
    private BoxCollider boxColl;

    
    // Start is called before the first frame update
    void Start()
    {
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
        if (enemyHeal.actualHP == 0)
        {   
            
            NMPatrol.isDeath = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            boxColl.enabled = false;
            Invoke("LeavingTheMap", 10f);
        }

    }

    void LeavingTheMap()
    {
        
        rb.useGravity = true;
        gameObject.GetComponent<NavMeshAgent>().enabled = false;

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
