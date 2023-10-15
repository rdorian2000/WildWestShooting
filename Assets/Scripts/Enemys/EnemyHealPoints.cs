using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealPoints : MonoBehaviour
{
    public delegate void EnemySystem(string uniqueID);
    public static event EnemySystem Death;

    public Slider enemyHealPointBar;
    public int actualHP;
    public int maxHP;

    void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            maxHP = Random.Range(3, 6);
        }
        else if(gameObject.tag == "PianoMan")
        {
            maxHP = Random.Range(10, 16);
        }
        actualHP = maxHP;     
        enemyHealPointBar.maxValue = maxHP;
        enemyHealPointBar.value = actualHP;
        enemyHealPointBar.fillRect.gameObject.SetActive(false);

        Debug.Log(gameObject.GetInstanceID().ToString());
    }

    void Update()
    {     
        enemyHealPointBar.fillRect.gameObject.SetActive(true);
        enemyHealPointBar.value = actualHP;
        EnemyDeath();
    }

    public void TakeDamage()
    {
        actualHP -= 1;
    }

    void EnemyDeath()
    {
        if(actualHP <= 0)
        {
            if(Death != null)
            {
                Death(gameObject.GetInstanceID().ToString());
            }
        }
    }

}
