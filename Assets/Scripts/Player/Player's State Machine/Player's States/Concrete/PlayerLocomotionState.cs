
using UnityEngine;

public class PlayerLocomotionState : PlayerState
{
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
