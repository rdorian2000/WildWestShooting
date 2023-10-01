using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveForward : MonoBehaviour
{  
    public float enemyMoveSpeed;
    public bool isDeath;
    private Animator animator;
    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        isDeath = false;
    }

    // Update is called once per frame
    void Update()
    {  
        Walking();
        
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

}
