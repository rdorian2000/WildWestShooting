using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharachterDamage : MonoBehaviour
{
    //public event Action GameOver;

    public int playerHP;
    public GameObject[] standartHealthPoints;
    public GameObject[] bonusHealthPoints;
    public GameObject[] GUIbloodDropp;
    private int bloodDroppIndex;
    private void Start()
    {
        playerHP = 3;

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

    public IEnumerator PlayerDamage()
    {
        if (playerHP != 0)
        {
            playerHP -= 1;
            bloodDroppIndex = UnityEngine.Random.Range(0, GUIbloodDropp.Length);
            GUIbloodDropp[bloodDroppIndex].SetActive(true);
            yield return new WaitForSeconds(1f);
            GUIbloodDropp[bloodDroppIndex].SetActive(false);
            Debug.Log("Sebzõdtél egy életet!");
            if (playerHP == 0)
            {
                Debug.Log("GameOver!!!");
                Time.timeScale = 0;
                yield return null;
            }
        }
        
        
    }

   
}
