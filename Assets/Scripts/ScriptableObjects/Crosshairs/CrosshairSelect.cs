using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSelect : MonoBehaviour
{
    [SerializeField] private CrosshairImages crosshairImages;
    public GameObject menuCrosshairImage;    
    public int actualCrosshairNumber;
    public int crosshairIndex;
    private void Start()
    {
        //Select the crosshair or load the crosshair.
        if (PlayerPrefs.HasKey("crosshair_index"))
        {
            actualCrosshairNumber = PlayerPrefs.GetInt("crosshair_index");
            menuCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
            menuCrosshairImage.GetComponent<Image>().color = new Color(0, 0, 0);
        }
        else
        {
            crosshairIndex = PlayerPrefs.GetInt("crosshair_index");
            menuCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
            menuCrosshairImage.GetComponent<Image>().color = new Color(0, 0, 0);
        }
              
    }
    //The player can in the options menu select the crosshair.
    public void RightButtonClick()
    {
        if (actualCrosshairNumber < crosshairImages.crosshairImageFiles.Length - 1)
        {
            actualCrosshairNumber += 1;
            menuCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
            SaveCrosshair(actualCrosshairNumber);
        }
        else {return;}          
    }
    //The player can in the options menu select the crosshair. 
    public void LeftButtonClick()
    {
        if(actualCrosshairNumber > 0)
        {
            actualCrosshairNumber -= 1;
            menuCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
            SaveCrosshair(actualCrosshairNumber);
        }
        else {return;}
    }   

    //Save the crosshair.
    public void SaveCrosshair(int index)
    {
        crosshairIndex = index;
        PlayerPrefs.SetInt("crosshair_index", crosshairIndex);
        PlayerPrefs.Save();
    }
}
