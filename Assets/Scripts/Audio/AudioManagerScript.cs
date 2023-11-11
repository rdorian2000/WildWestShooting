using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds, musics;  
    public GameObject soundGameObject, musicGameObject;
    public static AudioManagerScript Instance;
    public bool mute;
    void Awake()
    {
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

    public void ToggleMusic()
    {
        foreach (Sound m in musics)
        {
            m.musicSource.mute = !m.musicSource.mute;
            if(m.musicSource.mute == true)
            {
                mute = true;
            }
            else
            {
                mute = false;
            }
        }
        
    }

    public void MusicVolume(float musicVolume)
    {
        foreach (Sound m in musics)
        {
            m.musicSource.volume = musicVolume;
            PlayerPrefs.SetFloat("music_volume", m.musicSource.volume);
            PlayerPrefs.Save();
        }
    }

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
