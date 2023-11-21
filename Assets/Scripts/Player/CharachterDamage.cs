using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharachterDamage : MonoBehaviour
{
    public static event Action theEnd;

    public int playerHP;
    public GameObject[] standartHealthPoints;
    public GameObject[] GUIbloodDropp;
    private int bloodDroppIndex;
    private int healPointIndex;

    private int actualHeartID;
    public GameObject[] heartObjects;
    private void Start()
    {
        playerHP = 3;
        healPointIndex = 2;
        actualHeartID = 0;
        StartCoroutine(RandomHeartOnTheMap());
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
    //When the player shoots the heart object on the map, he becomes HP.
    public void AddPlayerHP()
    {
        if(playerHP != 0 && playerHP != 3)
        {        
            if (playerHP == 2 || playerHP == 1)
            {
                playerHP++;
                healPointIndex++;
                standartHealthPoints[healPointIndex].SetActive(true);                          
                heartObjects[actualHeartID].gameObject.SetActive(false);
            }
        }
        else
        {
            heartObjects[actualHeartID].gameObject.SetActive(false);
        }
    }
    //Random heart object on the map.
    public IEnumerator RandomHeartOnTheMap()
    {   
        for(; ; )
        {
            yield return new WaitForSeconds(UnityEngine.Random.Range(20f,40f));
            actualHeartID = UnityEngine.Random.Range(0, heartObjects.Length);
            heartObjects[actualHeartID].gameObject.SetActive(true);
            yield return new WaitForSeconds(15f);
            heartObjects[actualHeartID].gameObject.SetActive(false);
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
