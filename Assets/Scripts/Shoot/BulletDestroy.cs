using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private CharacterController charachterContrl;
    private float bulletLimitZ;
    private float bulletLimitX;
    
    void Start()
    {
        charachterContrl = GameObject.Find("Player").GetComponent<CharacterController>();
    }
    void Update()
    {
        BulletDestroyer();
    }

    void BulletDestroyer()
    {
        if(charachterContrl.backward)
        {
            bulletLimitZ = -50f;
            bulletLimitX = 20f;

            if (transform.position.z < bulletLimitZ)
            {
                Destroy(gameObject);
            }
            else if (transform.position.x < -bulletLimitX)
            {
                Destroy(gameObject);
            }
            else if (transform.position.x > bulletLimitX)
            {
                Destroy(gameObject);
            }
        }

        if (charachterContrl.forward)
        {
            bulletLimitZ = 25f;
            bulletLimitX = 20f;

            if (transform.position.z > bulletLimitZ)
            {
                Destroy(gameObject);
            }
            else if (transform.position.x < -bulletLimitX)
            {
                Destroy(gameObject);
            }
            else if (transform.position.x > bulletLimitX)
            {
                Destroy(gameObject);
            }
        }

        if (charachterContrl.right)
        {
            bulletLimitX = 40f;
            bulletLimitZ = 20f;

            if (transform.position.x > bulletLimitX)
            {
                Destroy(gameObject);
            }
            else if (transform.position.z < -bulletLimitZ)
            {
                Destroy(gameObject);
            }
            else if (transform.position.z > bulletLimitZ)
            {
                Destroy(gameObject);
            }
        }

        if (charachterContrl.left)
        {
            
            bulletLimitX = -35f;
            bulletLimitZ = 20f;

            if (transform.position.x < bulletLimitX)
            {
                Destroy(gameObject);
            }
            else if (transform.position.z < -bulletLimitZ)
            {
                Destroy(gameObject);
            }
            else if (transform.position.z > bulletLimitZ)
            {
                Destroy(gameObject);
            }
        }

    }
}
