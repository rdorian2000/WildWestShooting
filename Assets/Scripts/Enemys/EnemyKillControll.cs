using UnityEngine;
using UnityEngine.AI;

public class EnemyKillControll : MonoBehaviour
{    
    public GameObject enemyCharacter;
    public GameObject enemyHealBar;

    private NavMeshAgent navMeshAgent;
    private Rigidbody rb;
    private BoxCollider boxColl;
    private Animator animator;

    public bool playPiano = false;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void Start()
    {       
        enemyHealBar.SetActive(true);
        rb = GetComponent<Rigidbody>();
        boxColl = GetComponent<BoxCollider>();
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        EnemyHealPoints.Death += DeadCharachter;
    }

    void OnDisable()
    {
        EnemyHealPoints.Death -= DeadCharachter;
    }

    void DeadCharachter(string uniqueID)
    {
        if ((gameObject.tag == "Civilian" || gameObject.tag == "Enemy") && uniqueID == gameObject.GetInstanceID().ToString()){          
            animator.SetBool("isDeath", true);
            navMeshAgent.speed = 0;          
            enemyHealBar.SetActive(false);
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            boxColl.enabled = false;
            Invoke("LeavingTheMap", 10f);
        }
        
        if (gameObject.tag == "PianoMan" && uniqueID == gameObject.GetInstanceID().ToString())
        {                         
            if (animator.GetBool("isPlay"))
            {              
                gameObject.transform.position = new Vector3(5.25f, transform.position.y, transform.position.z);               
            }           
            animator.SetBool("isDeath", true);           
            navMeshAgent.speed = 0;
            enemyHealBar.SetActive(false);
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


}
