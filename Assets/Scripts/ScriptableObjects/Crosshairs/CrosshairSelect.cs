using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSelect : MonoBehaviour
{
    [SerializeField] private CrosshairImages crosshairImages;

    public GameObject actualCrosshairImage;
    public int actualCrosshairNumber = 0;

    private void Start()
    {           
        actualCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
        actualCrosshairImage.GetComponent<Image>().color = new Color(0, 0, 0);
        if (!PlayerPrefs.HasKey("crossHair"))
        {
            PlayerPrefs.SetFloat("crossHair",0);
            Load();
        }
        else
        {
            Load();
        }
    }
    public void RightButtonClick()
    {
        if (actualCrosshairNumber < crosshairImages.crosshairImageFiles.Length - 1)
        {
            actualCrosshairNumber += 1;
            actualCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
            Save();
        }
        else { Load(); return; }
            
    }
    public void LeftButtonClick()
    {
        if(actualCrosshairNumber > 0)
        {
            actualCrosshairNumber -= 1;
            actualCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
            Save();
        }
        else { Load(); return; }
    }

    private void Load()
    {
        actualCrosshairNumber = PlayerPrefs.GetInt("crossHair");
    }

    private void Save()
    {
        PlayerPrefs.SetInt("crossHair", actualCrosshairNumber);
    }


}
