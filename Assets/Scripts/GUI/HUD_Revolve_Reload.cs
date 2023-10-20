using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Revolve_Reload : MonoBehaviour
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
        CharacterController.hudRevolveReload += WhenReloadRotateTheRevolve;
    }

    void OnDisable()
    {
        CharacterController.hudRevolveReload -= WhenReloadRotateTheRevolve;
    }

    void WhenReloadRotateTheRevolve()
    {
        //hudGUIrevolve.transform.position = Vector3(0,0,1).Lerp(new Vector3(0, 0, 1), new Vector3(0, 0, 360), 100f);
        Debug.Log("Most forog");
    }
  
}
