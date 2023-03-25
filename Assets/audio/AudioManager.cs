using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    public string MainTheme;

    private void Awake()
    {
        foreach(Sound sound in Sounds)
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.clip = sound.clip;
            sound.AudioSource.volume = sound.Volume;
            sound.AudioSource.pitch = sound.Pitch;
            sound.AudioSource.loop = sound.Loop;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Play(MainTheme);
    }

    public void Play(string SoundName)
    {
        Sound s = Array.Find(Sounds, Sound => Sound.Name == SoundName);

        s.AudioSource.Play();
    }
}
