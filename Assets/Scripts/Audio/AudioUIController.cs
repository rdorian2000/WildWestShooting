using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _soundSlider;
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

    public void SoundVolume()
    {
        AudioManagerScript.Instance.SoundVolume(_soundSlider.value);
    }

}
