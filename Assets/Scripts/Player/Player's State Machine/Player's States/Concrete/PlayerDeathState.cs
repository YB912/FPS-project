using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerDeathState : PlayerState
{

    public PlayerDeathState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {
        Cursor.lockState = CursorLockMode.None;

        Cursor.visible = true;

        //PlayerInfo.instance.GetComponent<PlayerInput>().SwitchCurrentActionMap("DeathMenu");

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
