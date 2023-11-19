using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Reflection;

public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds, musics;  
    public GameObject soundGameObject, musicGameObject;
    public static AudioManagerScript Instance;
    public bool mute;
    void Awake()
    {
        //Don't destroy on load.
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        
        //All music is a new instance with options.
        foreach (Sound m in musics)
        {
            m.musicSource = musicGameObject.AddComponent<AudioSource>();
            m.musicSource.clip = m.clip;
            m.musicSource.playOnAwake = false;
            m.musicSource.volume = m.volume;
            m.musicSource.pitch = m.pitch;
            m.musicSource.loop = m.loop;
            m.musicSource.volume = 1.0f;
        }
        //All sound is a new instance with options.
        foreach (Sound s in sounds)
        {
            s.soundSource = soundGameObject.AddComponent<AudioSource>();
            s.soundSource.clip = s.clip;
            s.soundSource.playOnAwake = false;
            s.soundSource.volume = s.volume;
            s.soundSource.pitch = s.pitch;
            s.soundSource.loop = s.loop;
        }          
    }
    private void Start()
    {
        PlayMusic("ThemeSound");
    }

    //Play the music.
    public void PlayMusic(string name)
    {
        Sound m = Array.Find(musics, music => music.name == name);

        if (m == null)
        {
            Debug.LogWarning("Music : " + name + "not found!");
            return;
        }                   
        m.musicSource.Play();       
    }
    //Play the sound.
    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + "not found!");
            return;
        }        
        s.soundSource.Play();
        
    }
    //Stop the sound.
    public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + "not found!");
            return;
        }
        s.soundSource.Stop();
    }
    //Stop the music.
    public void StopMusic(string name)
    {
        Sound m = Array.Find(musics, music => music.name == name);

        if (m == null)
        {
            Debug.LogWarning("Sound : " + name + "not found!");
            return;
        }
        m.musicSource.Stop();
    }
    //Music mute.
    public void ToggleMusic()
    {
        foreach (Sound m in musics)
        {
            m.musicSource.mute = !m.musicSource.mute;
            if (m.musicSource.mute == false)
            {
                mute = false;
            }
            else
            {
                mute = true;
            }
        }      
    }
    //Music volume value save.
    public void MusicVolume(float musicVolume)
    {
        foreach (Sound m in musics)
        {
            m.musicSource.volume = musicVolume;
            PlayerPrefs.SetFloat("music_volume", m.musicSource.volume);
            PlayerPrefs.Save();
        }
    }
    //Sound volume value save.
    public void SoundVolume(float soundVolume)
    {
        foreach (Sound s in sounds)
        {
            s.soundSource.volume = soundVolume;
            PlayerPrefs.SetFloat("sound_volume", s.soundSource.volume);
            PlayerPrefs.Save();
        }
    }
}
