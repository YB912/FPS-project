
using UnityEngine;

public class PlayerAirborneState : PlayerState
{
    public PlayerAirborneState(StateMachine stateMachine) : base(stateMachine)
    {

    }

    public override void OnEnter()
    {

    }

    public override void Update()
    {
        if (stateMachine.GetComponent<CharacterController>().isGrounded)
        {
            stateMachine.ChangeState(new PlayerLocomotionState(stateMachine));
        }
        playerStateMachine.playerMovement.Update();
        playerStateMachine.playerLook.Update();
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
