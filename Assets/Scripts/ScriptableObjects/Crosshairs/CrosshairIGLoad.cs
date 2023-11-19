using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairIGLoad : MonoBehaviour
{
    [SerializeField] private CrosshairImages crosshairImages;
    public GameObject inGameCrosshairImage;
    public int inGameCrosshairIndex;
    
    void Start()
    {
        CrosshairLoad();
    }

    //Load the crosshair in game.
    public void CrosshairLoad()
    {
        if (PlayerPrefs.HasKey("crosshair_index"))
        {
            inGameCrosshairIndex = PlayerPrefs.GetInt("crosshair_index");
        }
        inGameCrosshairImage.GetComponent<Image>().sprite = crosshairImages.crosshairImageFiles[inGameCrosshairIndex];
        inGameCrosshairImage.GetComponent<Image>().color = new Color(1, 1, 1);
    }
}
