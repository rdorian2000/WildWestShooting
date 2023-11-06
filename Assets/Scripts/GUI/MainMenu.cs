using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour   
{
    public Toggle musicToggle;
    public void PlayGame()
    {
        AudioManagerScript.Instance.StopMusic("ThemeSound");
        AudioManagerScript.Instance.PlayMusic("WorldSound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
