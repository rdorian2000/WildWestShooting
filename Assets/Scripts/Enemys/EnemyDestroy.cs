using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{
    private CharacterController charachterContrl;
    private void Start()
    {
        charachterContrl = GameObject.Find("Player").GetComponent<CharacterController>();
    }

    void Update()
    {
        EnemyoutOfMap();
    }

    void EnemyoutOfMap()
    {
        if (charachterContrl.backward)
        {
            if (transform.position.z > 0)
            {
                Destroy(gameObject);        
            }
        }

        if (charachterContrl.forward)
        {
            if (transform.position.z < 0)
            {
                Destroy(gameObject);
            }
        }

        if (charachterContrl.right)
        {
            if (transform.position.x < 0)
            {
                Destroy(gameObject);
            }
        }

        if (charachterContrl.left)
        {
            if (transform.position.x > 0)
            {
                Destroy(gameObject);
            }
        }

    }
}
