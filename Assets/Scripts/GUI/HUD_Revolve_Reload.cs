using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD_Revolve_Reload : MonoBehaviour
{
    public GameObject hudGUIrevolve;
    public GameObject[] hudGUIbullets;
    private int bulletNumber;
    private Animator animator; 

    private void Start()
    {
        animator = GetComponent<Animator>();
             
    }
    void OnEnable()
    {
        CharacterController.hudRevolveReload += Starter;
    }

    void OnDisable()
    {
        CharacterController.hudRevolveReload -= Starter;
    }


    public void Starter()
    {
        StartCoroutine(WhenReloadRotateTheRevolve());
    }
    public IEnumerator WhenReloadRotateTheRevolve()
    {      
        bulletNumber = 0;
        animator.SetBool("isReloading",true);
        while(bulletNumber < 6)
        {
            yield return new WaitForSeconds(0.5f);

            if (bulletNumber != 5)
            {
                hudGUIbullets[bulletNumber].gameObject.SetActive(true);
                bulletNumber += 1;             
            }                    

            if (bulletNumber == 5)
            {
                animator.SetBool("isReloading", false);
            }
        }               
    }
}
