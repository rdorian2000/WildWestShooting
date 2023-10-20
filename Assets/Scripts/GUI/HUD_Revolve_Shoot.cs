using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Revolve_Shoot : MonoBehaviour
{
    public GameObject hudGUIrevolve;
    public GameObject[] hudGUIbullets;
    private int bulletNumber;
    
    private void Start()
    {
        bulletNumber = 0;
    }
    void OnEnable()
    {
        CharacterController.hudRevolveShoot += WhenShootRotateTheRevolve;
    }

    void OnDisable()
    {
        CharacterController.hudRevolveShoot -= WhenShootRotateTheRevolve;
    }

    void WhenShootRotateTheRevolve()
    {
        if (bulletNumber >= 0)
        {
            if (bulletNumber < hudGUIbullets.Length)
            {
                hudGUIbullets[bulletNumber].gameObject.SetActive(false);
                hudGUIrevolve.transform.Rotate(new Vector3(0, 0, -1), 90f);
                bulletNumber += 1;
            }
        }                    
    }
  
}
