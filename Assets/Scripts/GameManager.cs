using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public TextMeshProUGUI scoreText;
    public GameObject gameOverCanvasObject;
    public Camera cameraFPS;
    public Camera cameraMain;
    public GameObject hud;
    private bool gameEnd = false;
    public int playerScore= 0;
    public GameObject enemySpawn;

    private void OnEnable()
    {
        CharachterDamage.theEnd += GameOverCanvas;
    }

    private void OnDisable()
    {
        CharachterDamage.theEnd -= GameOverCanvas;
    }

    public void Start()
    {      
        gameOverCanvasObject.SetActive(false);
        MouseCursorLock();           
        StartCoroutine(Counter());
    }
    public void Update()
    {
        scoreText.text = playerScore.ToString();
        if (gameEnd)
        {
            cameraMain.transform.Rotate(Vector3.up*0.1f, Space.Self);
        }
    }
    public void AddScore(int score)
    {
        playerScore += score;
        Debug.Log("Your Score:" + playerScore);
        if (playerScore < 0)
        {
            GameOverCanvas();
        }
    }

    void GameOverCanvas()
    {
        Debug.Log("GameOver!!!");
        Time.timeScale = 0;
        hud.SetActive(false);
        cameraFPS.enabled = false;
        MouseCursorUnlock();
        gameOverCanvasObject.SetActive(true);
        gameEnd = true;

    }

    public void RestartGame()
    {
        //Restart the game.
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        

    }

    public void GoToMenu()
    {
        //Back to the main menu.
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }

    public IEnumerator Counter()
    {
        yield return new WaitForSeconds(1.5f);
        Debug.Log("5");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("4");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("3");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.5f);
        Debug.Log("Start");
        yield return null;

        enemySpawn.SetActive(true);
    }

    //When start the game, this lock the cursor.
    void MouseCursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    //When end the game, this unlock the cursor.
    void MouseCursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }







}
