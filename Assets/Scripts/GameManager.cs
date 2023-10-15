using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;

    public int playerScore= 0;

    public void Update()
    {
        scoreText.text = playerScore.ToString();
    }
    public void AddScore(int score)
    {
        playerScore += score;
        Debug.Log("Your Score:" + playerScore);
    }




}
