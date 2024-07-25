using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class SoundManager : MonoBehaviour
{

    public AudioSource soundMusic;
    public AudioSource soundSFX;
    public audio[] audios;


    private static SoundManager instance;
    public static SoundManager Instance
    { get { return instance; } }
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
   

    public void play(soundplaces sounds)
    {
        AudioClip clip = Getsoundclip(sounds);
        if (clip != null)
        {
            soundSFX.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("clip didnot found");
        }
    }




    private AudioClip Getsoundclip(soundplaces sounds)
    {
        audio item = Array.Find(audios, i => i.audioType == sounds);
        if (item != null)
        {
            return item.audioClip;

        }
        return null;
    }
}
[Serializable]
public class audio
{
    public soundplaces audioType;
    public AudioClip audioClip;
}

public enum soundplaces
{
   
    Obsticles,
    Playerland,
    Playerdeath,
    environmentMusic,
    genricPickup,
    LevelComplete,
        Button,
        Button2,
        platformer,
}
