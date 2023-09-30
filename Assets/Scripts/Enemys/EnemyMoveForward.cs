using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{
    
    private EnemyKillControll eKillContrl;
    public float enemyMoveSpeed;
    public bool isDeath;
    private Animator animator;
    private Rigidbody rb;
    private BoxCollider boxColl;

    public int shootNumberForKill;
    // Start is called before the first frame update
    void Start()
    {
        
        eKillContrl = GetComponent<EnemyKillControll>();
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        boxColl = GetComponent<BoxCollider>();
        isDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        Death();
        Walking();
        EnemyoutOfMap();
    }

    void Walking()
    {
        if (isDeath == false)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * enemyMoveSpeed);
        }
        else
        {
            rb.freezeRotation = false;
            animator.SetBool("isDeath", true);
        }
    }

    void Death()
    {
        if (eKillContrl.shootNumber > shootNumberForKill)
        {
            
            isDeath = true;
            rb.constraints = RigidbodyConstraints.FreezePosition;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            boxColl.enabled = false;
            Invoke("LeavingTheMap",10f);
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

    void EnemyoutOfMap()
    {
        if (transform.position.z > (-3))
        {
            Destroy(gameObject);
            Debug.Log("Enemy leave the map!!!");
        }
    }
}
