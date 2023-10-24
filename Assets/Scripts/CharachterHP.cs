using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterHP : MonoBehaviour
{
    int bulletNumber;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Fut a script");
        bulletNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("RevolverBullet"))
        {
            bulletNumber += 1;
            Debug.Log("A pisztolygolyó eltalálta a karaktert!" + bulletNumber);
            
        }
    }
}
