using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{ 
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI endScoreText;
    public TextMeshProUGUI endTimeText;
    public GameObject gameOverCanvasObject;
    public Camera cameraFPS;
    public Camera cameraMain;
    public GameObject hud;
    public GameObject pauseMenu;
    public static bool gameEnd = false;
    public GameObject enemySpawn;
    private float elapsedTime;


    public SavePlayerData.Player playerData;


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
        scoreText.text = playerData.playerScore.ToString();
        Timer();
        if (gameEnd)
        {
            cameraMain.transform.Rotate(Vector3.up*0.1f, Space.Self);
        }
    }
    public void AddScore(int score)
    {
        playerData.playerScore += score;
        Debug.Log("Your Score:" + playerData.playerScore);
        if (playerData.playerScore < 0)
        {
            endScoreText.text = playerData.playerScore.ToString();
            GameOverCanvas();
        }
    }

    void GameOverCanvas()
    {
        gameEnd = true;
        PauseMenu.GameIsPaused = true;
        AudioManagerScript.Instance.StopSound("RevolverReloadSound");
        Debug.Log(SavePlayerData.Player.playerName);
        Debug.Log(playerData.playerScore);
        Debug.Log(playerData.playerTime);
        Debug.Log(SavePlayerData.Player.actualDate.ToString("yyyy-MM-dd"));
        Debug.Log(SavePlayerData.Player.crosshairIndex);   
        Debug.Log("GameOver!!!");
        AudioManagerScript.Instance.PlaySound("GameOverSound");
        Time.timeScale = 0;
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        cameraFPS.enabled = false;
        endScoreText.text = playerData.playerScore.ToString();
        MouseCursorUnlock();
        gameOverCanvasObject.SetActive(true);
        
    }

    public void Timer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        playerData.playerTime = string.Format("{00:00}:{01:00}", minutes, seconds); //Kimenteni való idõ!!!
        endTimeText.text = playerData.playerTime;
    }
    public void RestartGame()
    {
        //Restart the game.
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }
   
    public void GoToMenu()
    {
        //Back to the main menu.       
        Time.timeScale = 1;
        PauseMenu.GameIsPaused = false;
        AudioManagerScript.Instance.StopSound("WorldSound");
        AudioManagerScript.Instance.PlayMusic("ThemeSound");        
            
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
