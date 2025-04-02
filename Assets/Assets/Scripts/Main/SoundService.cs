using System;
using Assets.Scripts.Utilities;
using UnityEngine;

namespace Assets.Scripts.Main
{
    public class SoundService : GenericMonoSingleton<SoundService>
    {
        [SerializeField] private AudioSource soundMusic;
        [SerializeField] private AudioSource soundSFX;
        [SerializeField] private audio[] audios;

        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        public void Play(SoundType sounds)
        {
            AudioClip clip = GetSoundClip(sounds);
            if (clip != null)
            {
                soundSFX.PlayOneShot(clip);
            }
            else
            {
                Debug.Log("clip not found");
            }
        }

        private AudioClip GetSoundClip(SoundType sounds)
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
}