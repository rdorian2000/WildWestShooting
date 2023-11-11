using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject inGameHUD;

    public static bool GameIsPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }            
        }
      
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        inGameHUD.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        AudioManagerScript.Instance.StopSound("RevolverReloadSound");
        GameIsPaused = true;
        inGameHUD.SetActive(false);
        pauseMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

}
