using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject inGameHUD;
    public GameObject optionMenu;
    public static bool GameIsPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused && optionMenu.activeInHierarchy == false)
            {
                Resume();
            }
            else
            {
                Pause();
            }            
        }
      
    }

    //The resume button.
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        inGameHUD.SetActive(true);
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    //The pause button.
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
