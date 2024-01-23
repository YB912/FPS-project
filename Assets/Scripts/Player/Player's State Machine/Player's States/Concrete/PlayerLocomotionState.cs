
using UnityEngine;

public class PlayerLocomotionState : PlayerState
{
    private PlayerStateMachine playerStateMachine;
    public PlayerLocomotionState(StateMachine stateMachine) : base(stateMachine)
    {
        playerStateMachine = (PlayerStateMachine)stateMachine;
    }

    public override void OnEnter()
    {
        
    }

    public override void Update()
    {
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
