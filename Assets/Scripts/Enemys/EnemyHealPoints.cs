using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealPoints : MonoBehaviour
{
    public Slider enemyHealPointBar;

    public int actualHP;
    public int maxHP;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Enemy")
        {
            maxHP = Random.Range(1, 6);
        }else if(gameObject.tag == "PianoMan")
        {
            maxHP = Random.Range(5, 11);
        }
        actualHP = maxHP;
        enemyHealPointBar.maxValue = maxHP;
        enemyHealPointBar.value = actualHP;
        enemyHealPointBar.fillRect.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        enemyHealPointBar.fillRect.gameObject.SetActive(true);
        enemyHealPointBar.value = actualHP;

    }

    public void TakeDamage()
    {
        actualHP -= 1;
    }

}
