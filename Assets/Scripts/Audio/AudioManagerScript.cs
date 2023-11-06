using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManagerScript : MonoBehaviour
{
    public Sound[] sounds, musics;
    public AudioSource soundSource, musicSource;
    public static AudioManagerScript Instance;  
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
    }

    private void Start()
    {    
        musicSource.volume = 1.0f;
        PlayMusic("ThemeSound");

    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musics, music => music.name == name);

        if (s == null)
        {
            Debug.LogWarning("Music : " + name + "not found!");
            return;
        }
        else
        {          
            musicSource.clip = s.clip;
            musicSource.volume = s.volume;
            musicSource.pitch = s.pitch;
            musicSource.loop = s.loop;
            musicSource.Play();
        }
    }

    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + "not found!");
            return;
        }
        else
        {
            soundSource.Play();
        }
    }

    /*public void StopSound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + "not found!");
            return;
        }
        s.Stop();
    }*/

    /*public void StopMusic(string name)
    {
        Sound s = Array.Find(musics, music => music.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound : " + name + "not found!");
            return;
        }
        musicSource.Stop();
    }*/

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void MusicVolume(float musicVolume)
    {
        musicSource.volume = musicVolume;
    }
}
