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

    public void SaveCrosshair(int index)
    {
        crosshairIndex = index;
        PlayerPrefs.SetInt("crosshair_index", crosshairIndex);
        PlayerPrefs.Save();
    }
}
