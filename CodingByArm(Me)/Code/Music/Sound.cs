using System;
using UnityEngine;

namespace MyPlatform
{
    [Serializable]
    public class Sound
    {
        public SoundManager.SoundName soundName;
        public AudioClip clip;
        [Range(0f, 1f)] public float volume;
        public bool loop;
        [HideInInspector] public AudioSource audioSource;
    }
}