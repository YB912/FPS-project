using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeathState : PlayerState
{
    public PlayerDeathState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {

        //Time.timeScale = 100f;

        //SceneManager.LoadScene(2);
        AudioManager.instance.PlaySound(AudioManager.Type.PLAYER_DEATH, GetComponent<AudioSource>(), 1);
    }

    public override void Update()
    {
    }

    public override void FixedUpdate()
    {

    }

    public override void OnExit()
    {

    }
}
