using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance {get; set;}
    public float mainVolume;

    private void Awake()
    {

        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        instance = this;

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }

    }

   

    public void Play(string name, float pitch)
    {
        mainVolume = (Settings.volume + 80) / 100;
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.pitch = pitch;
        s.source.volume = s.volume * mainVolume;
        s.source.Play();
    }

}
