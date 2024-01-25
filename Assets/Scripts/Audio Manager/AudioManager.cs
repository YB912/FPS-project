using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using static AudioInfo;

public class AudioManager : Singleton<AudioManager>
{

    private static Dictionary<AudioTypes.Type, float> _timeDictionary;
    

    public static void InitializDictionary()
    {
        _timeDictionary = new Dictionary<AudioTypes.Type, float>();

        _timeDictionary[AudioTypes.Type.PLAYER_WALK] = 0f;
        _timeDictionary[AudioTypes.Type.PLAYER_RUN] = 0f;
        _timeDictionary[AudioTypes.Type.PLAYER_JUMP] = 0f; //NOT SURE ABOUT THIS
        _timeDictionary[AudioTypes.Type.ZOMBIE_RUN] = 0f;


    }

    public static void PlaySound(AudioTypes.Type type)
    {
        if(CanPlay(type))
        {
            GameObject soundGO = new GameObject("Sound");
            AudioSource source = soundGO.AddComponent<AudioSource>();
            source.PlayOneShot(GetAudioClip(type));
        }

    }

    private static AudioClip GetAudioClip(AudioTypes.Type type)
    {

        AudioInfo audioInfoInstance = FindObjectOfType<AudioInfo>();

        if (audioInfoInstance != null && audioInfoInstance.audioClipsArray != null)
        {
            foreach (SoundAudioClips myClip in audioInfoInstance.audioClipsArray)
            {
                if (myClip != null && myClip.type == type && myClip.clip != null)
                {
                    return myClip.clip;
                }
            }
        }

        return null;
    }



    private static bool CanPlay(AudioTypes.Type type)
    {
        switch (type)
        {
            default: return true;
             
            case 0: //WHEN WE ADD A STATE TO THE DICTIONARY, IT WILL HAPPEN.
                if (_timeDictionary.ContainsKey(type))
                {
                    float lastTimePlay = _timeDictionary[type];
                    float repeatTime = GetAudioClip(type).length;

                    if(lastTimePlay + repeatTime < Time.time)
                    {
                        _timeDictionary[type] = Time.time;
                        return true;
                    }
                    else return false;
                }
                else return true;

        }
    }


}
