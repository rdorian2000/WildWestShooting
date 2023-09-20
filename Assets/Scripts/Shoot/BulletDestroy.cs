using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private float bulletLimitZ = 30f;
    private float bulletLimitX = 7.5f;
    // Update is called once per frame
    void Update()
    {
        BulletDestroyer();
    }

    void BulletDestroyer()
    {
        if (transform.position.z >= bulletLimitZ)
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
