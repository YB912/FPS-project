
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
        
    }

    public override void FixedUpdate()
    {
        var PSM = (PlayerStateMachine)stateMachine;
        PSM.playerMovement.ApplyMovement();
    }

    public override void OnExit()
    {
        
    }
}
