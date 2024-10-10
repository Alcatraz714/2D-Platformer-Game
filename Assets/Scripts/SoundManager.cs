using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance {get {return instance;}}
    public SoundType[] Sounds;
    public AudioSource soundEffect;
    public AudioSource soundMusic;
    private void Awake() {
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

    private void Start() {
        PlayMusic(global::Sounds.Music);
    }

    public void PlayMusic(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundMusic.clip = clip;
            soundMusic.Play(); // indefinite
        }
        else
        {
            Debug.LogError("NO Sound Clip found for : " + sound);
        }
    }

    public void PlaySound(Sounds sound)
    {
        AudioClip clip = GetSoundClip(sound);
        if (clip != null)
        {
            soundEffect.PlayOneShot(clip);
        }
        else
        {
            Debug.LogError("NO Sound Clip found for : " + sound);
        }
    }

    private AudioClip GetSoundClip(Sounds sound)
    {
        SoundType item =  Array.Find(Sounds, i=> i.soundType == sound);
        if (item != null)
        {
            return item.soundClip;
        }
        return null;
    }
}

[Serializable]
public class SoundType
{
    public Sounds soundType;
    public AudioClip soundClip;
}

public enum Sounds
{
    ButtonClick,
    Music,
    PlayerMove,
    PlayerDeath,
    EnemyDeath,
}
