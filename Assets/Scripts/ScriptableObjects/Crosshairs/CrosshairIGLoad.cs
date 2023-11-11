using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrosshairIGLoad : MonoBehaviour
{
    [SerializeField] private CrosshairImages crosshairImages;
    public GameObject inGameCrosshairImage;
    public int inGameCrosshairIndex;
    
    // Start is called before the first frame update
    void Start()
    {
        CrosshairLoad();
    }

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
