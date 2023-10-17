using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PianomanMoveScript : MonoBehaviour
{
    private Animator animator;
    //[SerializeField] private SpawnPointsList endPoint; 
    private GameObject pianoPoint;
    private NavMeshAgent navMeshAgent;
    private Transform target;

    public bool isPlayPiano = false;

    void Awake()
    {
        pianoPoint = GameObject.Find("PianomanEndPoint");
        target = pianoPoint.transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();  
        animator.SetBool("isPlay", isPlayPiano);
    }
    
    void Start()
    {
        navMeshAgent.destination = target.transform.position;
    }

    void Update()
    {
        if (isPlayPiano && gameObject.transform.rotation != pianoPoint.transform.rotation)
        {
            gameObject.transform.rotation = pianoPoint.transform.rotation;
        }
    }
    void OnCollisionEnter(Collision col)
    {      
        if (gameObject.tag == "PianoMan" && col.gameObject == pianoPoint)
        {          
            isPlayPiano = true;
            animator.SetBool("isPlay", isPlayPiano);
                                 
        }                                         
    }

}
