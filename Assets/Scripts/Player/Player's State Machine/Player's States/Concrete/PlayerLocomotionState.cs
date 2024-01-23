
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
        if (stateMachine.GetComponent<CharacterController>().isGrounded == false)
        {
            stateMachine.ChangeState(new PlayerAirborneState(stateMachine));
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
