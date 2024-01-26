
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{

    [SerializeField] public SoundAudioClip[] audioClipsArray;

    public void PlaySound(Type type, AudioSource source, float volume)
    {
        source.PlayOneShot(GetAudioClip(type), volume);
    }

    private AudioClip GetAudioClip(Type type)
    {
        if (audioClipsArray != null)
        {
            foreach (SoundAudioClip myClip in audioClipsArray)
            {
                if (myClip != null && myClip.type == type && myClip.clip != null)
                {
                    return myClip.clip;
                }
            }
        }
        return null;
    }

    [System.Serializable]
    public enum Type
    {
        PLAYER_RUN, PLAYER_JUMP, PLAYER_KICK, PLAYER_HURT, PLAYER_DEATH,
        ZOMBIE_RANDOM, ZOMBIE_ATTACK, ZOMBIE_DEATH, 
        SHOOTING, RELOADING, PULL_WEAPON, SPAWNER
    }

    [System.Serializable]
    public class SoundAudioClip
    {
        public AudioClip clip;
        public Type type;
    }
}
