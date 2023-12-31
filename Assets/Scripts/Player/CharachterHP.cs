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

    void OnTriggerEnter(Collider col)
    {       
        if (col.gameObject.tag =="RevolverBullet")
        {
            bulletNumber += 1;           
            WhenShootMe();
        }
    }
    //When the enemy shoots the player, he becomes damage.
    public void WhenShootMe()
    {
        if(playerDamage != null)
        {
            playerDamage();
        }
    }
}
