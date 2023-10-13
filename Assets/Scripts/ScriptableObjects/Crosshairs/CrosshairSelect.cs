using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairSelect : MonoBehaviour
{
    [SerializeField] private CrosshairImages crosshairImages;

    public GameObject actualCrosshairImage;
    public int actualCrosshairNumber;

    private void Start()
    {   
        actualCrosshairNumber = 0;
        actualCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
        actualCrosshairImage.GetComponent<Image>().color = new Color(0, 0, 0);
    }
    public void RightButtonClick()
    {
        if(actualCrosshairNumber < crosshairImages.crosshairImageFiles.Length-1)
        {
            actualCrosshairNumber += 1;
            actualCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
        }
        else {
            return;
        }
    }

    public void LeftButtonClick()
    {
        if(actualCrosshairNumber > 0)
        {
            actualCrosshairNumber -= 1;
            actualCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[actualCrosshairNumber];
        }
        else { return; }

    }
}
