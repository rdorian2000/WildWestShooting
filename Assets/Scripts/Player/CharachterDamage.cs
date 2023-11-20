using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterDamage : MonoBehaviour
{
    public static event Action theEnd;

    public int playerHP;
    public GameObject[] standartHealthPoints;
    public GameObject[] bonusHealthPoints;
    public GameObject[] GUIbloodDropp;
    private int bloodDroppIndex;
    private int healPointIndex;
    private void Start()
    {
        playerHP = 3;
        healPointIndex = 2;
    }

    private void OnEnable()
    {
        CharachterHP.playerDamage += Starter;
    }

    private void OnDisable()
    {
        CharachterHP.playerDamage -= Starter;
    }

    public void Starter()
    {
        StartCoroutine(PlayerDamage());
        
    }
    //When the enemy shoots the player, he becomes damage.
    public IEnumerator PlayerDamage()
    {
        if (playerHP != 0)
        {
            playerHP -= 1;
            bloodDroppIndex = UnityEngine.Random.Range(0, GUIbloodDropp.Length);
            GUIbloodDropp[bloodDroppIndex].SetActive(true);
            standartHealthPoints[healPointIndex].SetActive(false);
            healPointIndex -= 1;
            yield return new WaitForSeconds(1f);
            GUIbloodDropp[bloodDroppIndex].SetActive(false);         
            if (playerHP == 0)
            {
                GameOver();                
                yield return null;
            }
        }                
    } 

    public void GameOver()
    {
        if(theEnd != null)
        {
            theEnd();
        }
    }
}
