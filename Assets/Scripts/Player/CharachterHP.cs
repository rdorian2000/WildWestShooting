using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharachterHP : MonoBehaviour
{
    public static event Action playerDamage;

    int bulletNumber;
    void Start()
    {
        bulletNumber = 0;
    }

    //Sebz�d�s
    void OnCollisionEnter(Collision col)
    {
        
        if (col.gameObject.CompareTag("RevolverBullet"))
        {
            bulletNumber += 1;
            Debug.Log("A pisztolygoly� eltal�lta a karaktert!" + bulletNumber);
            WhenShootMe();
        }
    }

    public void WhenShootMe()
    {
        if(playerDamage != null)
        {
            playerDamage();
        }
    }
}
