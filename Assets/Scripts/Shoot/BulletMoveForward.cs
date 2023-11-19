using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveForward : MonoBehaviour
{
    public float bulletSpeed = 30f;
    //Bullet prefab fly forward.
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * bulletSpeed);
    }
}
