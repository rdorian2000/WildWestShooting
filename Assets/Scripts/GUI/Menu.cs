using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject hud;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            hud.SetActive(false);
            menu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;

        }
        else
        {
            hud.SetActive(true);
            menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
}
