using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using System.Linq;
using static SavePlayerData;

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
    private float elapsedTime;
    private int highScore;
    private string endTime;

    public GameObject gameMenu;
    public GameObject optionMenu;

    public TXTPlayer playerData;
    public static int playerNumber = 1;
    private Data gameData;

    //If the charachter HP is null, the game is over.
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
        gameMenu.SetActive(false);
        optionMenu.SetActive(false);
        gameEnd = false;
        gameOverCanvasObject.SetActive(false);
        MouseCursorLock();             
    }
    public void Update()
    {
        scoreText.text = highScore.ToString(); //This displays the score on the HUD.
        Timer();
        //Rotate the background camera, when the game is over.
        if (gameEnd)
        {
            cameraMain.transform.Rotate(Vector3.up*0.1f, Space.Self);
        }

    }
    //Add score, and save the high score.
    //When the highscore is <=0, the game is over.
    public void AddScore(int score)
    {
        highScore += score;
        endScoreText.text = highScore.ToString();
        PlayerPrefs.SetInt("high_score", highScore);
        PlayerPrefs.Save();
        if (highScore < 0)
        {         
            GameOverCanvas();
        }
    }
    //Enable the game over canvas with datas.
    void GameOverCanvas()
    {
        gameEnd = true;
        PauseMenu.GameIsPaused = true;
        AudioManagerScript.Instance.StopSound("RevolverReloadSound");
        GameEndData();
        if(PlayerPrefs.GetInt("high_score") >= 0)
        {
            SaveData();
        }
        AudioManagerScript.Instance.PlaySound("GameOverSound");
        Time.timeScale = 0;
        hud.SetActive(false);
        pauseMenu.SetActive(false);
        cameraFPS.enabled = false;
        endScoreText.text = PlayerPrefs.GetInt("high_score").ToString();
        MouseCursorUnlock();
        gameOverCanvasObject.SetActive(true);
        
    }

    //This saves the high time value.
    public void Timer()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        endTime = string.Format("{00:00}:{01:00}", minutes, seconds);
        endTimeText.text = endTime;
        PlayerPrefs.SetString("end_time", endTime);
        PlayerPrefs.Save();
    }
    //Restart button.
    public void RestartGame()
    {
        //Restart the game.
        PianomanMoveScript.StopAcutalMusic();
        PauseMenu.GameIsPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);       
    }
    //Exit button.
    public void GoToMenu()
    {
        //Back to the main menu.
        PianomanMoveScript.StopAcutalMusic();
        Time.timeScale = 1;
        PauseMenu.GameIsPaused = false;
        AudioManagerScript.Instance.StopSound("WorldSound");
        AudioManagerScript.Instance.PlayMusic("ThemeSound");                      
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
    

    //When start the game, this locks the cursor.
    void MouseCursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    //When end/pause the game, this unlocks the cursor.
    void MouseCursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    //Players datas.
    public void GameEndData()
    {
        gameData = new Data(playerNumber);

        for (int i = 0; i < gameData.players.Length; i++)
        {
            gameData.players[i] = new Player();
            gameData.players[i].playerName = PlayerPrefs.GetString("user_name");
            gameData.players[i].playerScore = PlayerPrefs.GetInt("high_score");
            gameData.players[i].playerTime = PlayerPrefs.GetString("end_time");
            gameData.players[i].crosshairIndex = PlayerPrefs.GetInt("crosshair_index");
            Debug.Log($"Player {i + 1} - Name: {gameData.players[i].playerName}, Score: {gameData.players[i].playerScore}, Time: {gameData.players[i].playerTime}, Crosshair Index: {gameData.players[i].crosshairIndex}");          
        }
    }

    // Creating JSON from Data and saving it to registry
    public void SaveData()
    {           
        string jsonData = JsonUtility.ToJson(gameData);     
        AppendDataToFile(jsonData);
    }
    //This adds the new data for the file.
    private void AppendDataToFile(string newData)
    {
        string saveFilePath = Application.dataPath + "/save.txt";
      
        if (File.Exists(saveFilePath))
        {          
            string existingData = File.ReadAllText(saveFilePath);          
            string updatedData = existingData + "\n" + newData;           
            File.WriteAllText(saveFilePath, updatedData);
        }
        else
        {           
            File.WriteAllText(saveFilePath, newData);
        }
    }

    


}
