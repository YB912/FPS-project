using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioInfo : MonoBehaviour
{
    public static int number = 100;

    [SerializeField] public SoundAudioClips[] audioClipsArray;

    [System.Serializable]
    public class SoundAudioClips
    {
        public AudioClip clip;
        public AudioTypes.Type type;
    }

}
