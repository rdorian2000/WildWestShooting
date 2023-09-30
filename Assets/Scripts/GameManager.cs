using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int playerScore= 0;


    public void AddScore(int score)
    {
        playerScore += score;
        Debug.Log("Your Score:" + playerScore);
    }



}
