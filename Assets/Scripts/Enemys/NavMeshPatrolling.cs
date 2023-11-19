using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPatrolling : MonoBehaviour
{
    [SerializeField] private SpawnPointsList endPointList;
    private Transform target;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        //The agent target point.
        if (gameObject.tag == "Enemy")
        {                      
            target = endPointList.spawnPoints[Random.Range(0, 3)].transform;
        }

        if (gameObject.tag == "Civilian")
        {
            target = endPointList.spawnPoints[Random.Range(0, 3)].transform;
        }

    }
 
    void Start()
    {
        navMeshAgent.destination = target.transform.position;
        StartCoroutine(DestroyCharachters());
    }
    //When the agent is in the target, destroy the agent.
    public IEnumerator DestroyCharachters()
    {       
        for(;;)
        {        
            if (Vector3.Distance(gameObject.transform.position, target.transform.position) <= 0.5f)
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(1f);
        }           
    }
  
}

