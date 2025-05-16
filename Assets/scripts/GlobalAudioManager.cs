using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GlobalAudioManager : MonoBehaviour
{
    public static GlobalAudioManager instance;

    public SoundClass[] MusicSounds, SfxSounds;
    public AudioSource MusicSource, MusicSource1, MusicSource2, MusicSource3 , SfxSource;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        SoundClass s = Array.Find(MusicSounds, x => x.nameClip == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource.clip = s.clip;
            MusicSource.Play();
        }
    }

    public void PlayMusic1(string name)
    {
        SoundClass s = Array.Find(MusicSounds, x => x.nameClip == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource1.clip = s.clip;
            MusicSource1.Play();
        }
    }

    public void PlayMusic2(string name)
    {
        SoundClass s = Array.Find(MusicSounds, x => x.nameClip == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource2.clip = s.clip;
            MusicSource2.Play();
        }
    }

    public void PlayMusic3(string name)
    {
        SoundClass s = Array.Find(MusicSounds, x => x.nameClip == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            MusicSource3.clip = s.clip;
            MusicSource3.Play();
        }
    }

    public void PlaySFX(string name)
    {
        SoundClass s = Array.Find(SfxSounds, x => x.nameClip == name);
        if (s == null)
        {
            Debug.Log("Sound Not Found");
        }
        else
        {
            SfxSource.PlayOneShot(s.clip);
        }
    }
}
