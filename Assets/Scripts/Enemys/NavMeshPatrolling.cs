using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolling : MonoBehaviour
{
    public bool isDeath;
    private Animator animator;
    private Rigidbody rb;

    private Transform target;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        target = GameObject.Find("EndPoint").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {       
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isDeath = false;
    }
    private void Update()
    {
        if (isDeath == false)
        {
            navMeshAgent.destination = target.transform.position;
        }
        else
        {
            rb.freezeRotation = false;
            navMeshAgent.speed= 0;
            animator.SetBool("isDeath", true);
        }
    }


}
