using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] private AudioSource soundMusic;
    [SerializeField] private AudioSource soundSFX;
    [SerializeField] private audio[] audios;


    private static SoundManager instance;
    public static SoundManager Instance   { get { return instance; } }
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
   

    public void Play(SoundType sounds)
    {
        AudioClip clip = Getsoundclip(sounds);
        if (clip != null)
        {
            soundSFX.PlayOneShot(clip);
        }
        else
        {
            Debug.Log("clip not found");
        }
    }




    private AudioClip Getsoundclip(SoundType sounds)
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
    public SoundType audioType;
    public AudioClip audioClip;
}

public enum SoundType
{
   
    Obstacles,
    PlayerLand,
    PlayerHurt,
    PlayerDeath,
    environmentMusic,
    genricPickup,
    LevelComplete,
    Button,
    Button2,
}
