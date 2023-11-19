using UnityEngine.Audio;
using UnityEngine;


//Sound class with the options values.
[System.Serializable]
public class Sound
{
    public string name; //Sound or music name.

    public AudioClip clip;

    [Range(0f, 1f)] public float volume=1f;

    [Range(0.1f, 3f)] public float pitch;

    public bool loop;

    [HideInInspector] public AudioSource soundSource, musicSource;


}
