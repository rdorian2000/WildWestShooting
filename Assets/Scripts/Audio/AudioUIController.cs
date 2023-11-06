using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    [SerializeField] Slider _musicSlider;
    [SerializeField] Image musicOff;

    public void ToggleMusic()
    {
        AudioManagerScript.Instance.ToggleMusic();
        musicOff.enabled = !musicOff.enabled;
    }

    public void MusicVolume()
    {
        AudioManagerScript.Instance.MusicVolume(_musicSlider.value);
    }

}
