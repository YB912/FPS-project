using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTypes : MonoBehaviour
{
    [System.Serializable]

    public enum Type
    {
        PLAYER_WALK, PLAYER_RUN, PLAYER_ATTACK, PLAYER_JUMP, PLAYER_DAMAGE, PLAYER_DEATH,
        ZOMBIE_RUN, ZOMBIE_ATTACK, ZOMBIE_DIE,
        SHOOTING, RELOADING, PULL_WEAPON,HIT,
    }
   
}
