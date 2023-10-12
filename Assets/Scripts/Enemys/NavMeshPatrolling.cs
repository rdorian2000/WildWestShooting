using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolling : MonoBehaviour
{
    private PianoManSpawnManager pianoManSpawn;
    
    public bool isDeath;
    private Animator animator;
    private Rigidbody rb;

    private Transform target;

    private NavMeshAgent navMeshAgent;

    bool EnemyGuy = false;
    bool PianoMan = false;

    private void Awake()
    {
        if(gameObject.tag == "Enemy")
        {
            EnemyGuy = true;
            target = GameObject.Find("EndPoint").transform;
        }else if(gameObject.tag == "PianoMan")
        {
            PianoMan = true;
            target = GameObject.Find("PianoManPianoPoint").transform;
        }
        
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        pianoManSpawn = GameObject.Find("PianoManSpawnManager").GetComponent<PianoManSpawnManager>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isDeath = false;
    }
    private void Update()
    {
        EnemyDeath(PianoMan, EnemyGuy);

    }

    void EnemyDeath(bool PianoMan, bool EnemyGuy)
    {
        if (EnemyGuy)
        {
            if (isDeath == false)
            {
                navMeshAgent.destination = target.transform.position;
            }
            else
            {
                rb.freezeRotation = false;
                navMeshAgent.speed = 0;
                animator.SetBool("isDeath", true);
            }
        }

        if (PianoMan)
        {
            if (isDeath == false)
            {
                navMeshAgent.destination = target.transform.position;
                animator.SetBool("isPlay", true);
            }
            else
            {
                pianoManSpawn.pianoManisDead = true;
                gameObject.transform.position = new Vector3(5.25f, transform.position.y, transform.position.z);
                rb.freezeRotation = false;
                navMeshAgent.speed = 0;
                animator.SetBool("isDeath", true);
            }
        }

    }


}

