using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private float bulletLimitZ = -50f;
    private float bulletLimitX = 12f;
    // Update is called once per frame
    void Update()
    {
        BulletDestroyer();
    }

    void BulletDestroyer()
    {
        if (transform.position.z < bulletLimitZ)
        {
            Destroy(gameObject);
        }else if(transform.position.x < -bulletLimitX)
        {
            Destroy(gameObject);
        }else if(transform.position.x > bulletLimitX)
        {
            Destroy(gameObject);
        }
    }
}
