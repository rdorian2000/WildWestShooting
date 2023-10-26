using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public int playerScore= 0;

    public void Start()
    {
        //J�t�k indul�sa.  
        //StartCoroutine(Counter());
    }
    public void Update()
    {
        scoreText.text = playerScore.ToString();
    }
    public void AddScore(int score)
    {
        playerScore += score;
        Debug.Log("Your Score:" + playerScore);
    }

    public void GameOver()
    {
        Debug.Log("GameOver!!!");
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        //J�t�k �jra ind�t�sa
    }

    /*public IEnumerator Counter()
    {

    }*/




}
