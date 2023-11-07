using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSelect : MonoBehaviour
{
    [SerializeField] private CrosshairImages crosshairImages;

    public GameObject menuCrosshairImage;
    //private GameObject inGameCrosshairImage;
    public int actualCrosshairNumber = 0;
    public static CrosshairSelect Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
     
    }

    private void Start()
    {
        menuCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
        menuCrosshairImage.GetComponent<Image>().color = new Color(0, 0, 0);      
    }
    public void RightButtonClick()
    {
        if (actualCrosshairNumber < crosshairImages.crosshairImageFiles.Length - 1)
        {
            actualCrosshairNumber += 1;
            menuCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];       
        }
        else {return;}          
    }
    public void LeftButtonClick()
    {
        if(actualCrosshairNumber > 0)
        {
            actualCrosshairNumber -= 1;
            menuCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];          
        }
        else {return;}
    }

    /*public void SetCrossHair()
    {
        inGameCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
        inGameCrosshairImage.GetComponent<Image>().color = new Color(1, 1, 1);
    }*/
}
