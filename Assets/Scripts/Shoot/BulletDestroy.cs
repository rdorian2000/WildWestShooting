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
    //Bullet destroy.
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

    }
}
