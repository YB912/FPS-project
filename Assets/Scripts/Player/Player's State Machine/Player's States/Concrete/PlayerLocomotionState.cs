
using UnityEngine;

public class PlayerLocomotionState : PlayerState
{
    private float _runSoundTimer;

    public PlayerLocomotionState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {
        
    }

    public override void Update()
    {
        //PlayerInfo player = new PlayerInfo();

        if (stateMachine.GetComponent<CharacterController>().isGrounded == false)
        {
            stateMachine.ChangeState(new PlayerAirborneState(stateMachine));
        }
        else if (PlayerInfo.instance.currentHealth == 0)
        {
            stateMachine.ChangeState(new PlayerDeathState(stateMachine));

        }
        playerStateMachine.playerMovement.Update();
        playerStateMachine.playerLook.Update();
        playerStateMachine.playerShooting.Update();

        if (playerStateMachine.playerMovement.velocity.x != 0 || playerStateMachine.playerMovement.velocity.z != 0)
        {
            _runSoundTimer += Time.deltaTime;
            if (_runSoundTimer >= PlayerInfo.instance.stepInterval)
            {
                AudioManager.instance.PlaySound(AudioManager.Type.PLAYER_RUN, playerStateMachine.GetComponent<AudioSource>(), 1);
                _runSoundTimer = 0;
            }
        }
    }

    public override void FixedUpdate()
    {
        playerStateMachine.playerMovement.Apply();
        playerStateMachine.playerLook.Apply();
    }

    public override void OnExit()
    {
        
    }
}
