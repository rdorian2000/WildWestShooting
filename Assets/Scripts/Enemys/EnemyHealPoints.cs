using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealPoints : MonoBehaviour
{
    public static event Action<string> Death;
    public static event Action Spawn;   

    public Slider enemyHealPointBar;
    public int actualHP;
    public int maxHP;

    void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            maxHP = UnityEngine.Random.Range(3, 6);
        }
        else if(gameObject.tag == "PianoMan")
        {
            maxHP = UnityEngine.Random.Range(10, 16);
        }else if(gameObject.tag == "Civilian")
        {
            maxHP = UnityEngine.Random.Range(1, 3);
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
        PianoManSpawn();
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

    void PianoManSpawn()
    {
        if(gameObject.tag == "PianoMan" && actualHP <= 0)
        {
            if(Spawn != null)
            {
                Spawn();
            }
        }
    }

}
