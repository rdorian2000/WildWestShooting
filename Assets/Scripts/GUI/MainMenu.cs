using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        FindObjectOfType<AudioManagerScript>().Play("ThemeSound");

    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<AudioManagerScript>().Stop("ThemeSound");
        FindObjectOfType<AudioManagerScript>().Play("WorldSound");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
