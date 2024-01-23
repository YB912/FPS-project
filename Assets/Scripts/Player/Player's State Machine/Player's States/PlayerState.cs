

public abstract class PlayerState : State
{
    protected PlayerStateMachine playerStateMachine;
    protected PlayerState(StateMachine stateMachine) : base(stateMachine)
    {
        playerStateMachine = (PlayerStateMachine)stateMachine;
    }
}
