using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUIController : MonoBehaviour
{
    [SerializeField] Slider _musicSlider;
    [SerializeField] Slider _soundSlider;
    [SerializeField] Image musicOffImage;
    [SerializeField] Toggle musicOnOffToggle;
    

    private void Start()
    {
        _musicSlider.value = PlayerPrefs.GetFloat("music_volume");
        _soundSlider.value = PlayerPrefs.GetFloat("sound_volume");    
        if(AudioManagerScript.Instance.mute == false)
        {          
            musicOffImage.enabled = true;           
        }
        else
        {
            musicOffImage.enabled =false;          
        }
    }
    public void ToggleMusic()
    {
        AudioManagerScript.Instance.ToggleMusic();
        musicOffImage.enabled = !musicOffImage.enabled;
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
