using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyPlatform
{
    public class SoundManager : Singleton<SoundManager>
    {

        [SerializeField] private Sound[] sounds;
        public enum SoundName
        {
            UISoundMenu,
            P_Walk,
            P_Run,
            P_B_Hit,
            P_Bush,
            P_Bent,
            P_Dead,
            M1_Run,
            M1_B_Hit,
            M1_Dead,
            BossTheme,
            GhostHunt,
            MenuMusic,
            EndMusic,
            MusicBG_Low_Forest,
            MusicBG_Normal_Forest,
            JumpScare_Bird,
            WalkOnStick,
            LogCollapse,
            RockCollapse,
            LogCutByAxe,
            WeedCutByMachete,
            BrokenTool,
            Dig,
            ReversePiano,
            //
        }



        public void Play(SoundName name)
        {
            //1. Get sound from array
            Sound sound = GetSound(name);
            if (sound.audioSource == null)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();

                sound.audioSource.clip = sound.clip;
                sound.audioSource.loop = sound.loop;
                sound.audioSource.volume = sound.volume;
            }

            //2.Play
            sound.audioSource.Play();
        }

        public void Stop(SoundName name)
        {
            Sound sound = GetSound(name);

            if (sound.audioSource == null)
            {
                sound.audioSource = gameObject.AddComponent<AudioSource>();

                sound.audioSource.clip = sound.clip;
                sound.audioSource.loop = sound.loop;
                sound.audioSource.volume = sound.volume;
            }

            sound.audioSource.Stop();

        }

        private Sound GetSound(SoundName name)
        {
            return Array.Find(sounds, s => s.soundName == name);
        }


    }
}

