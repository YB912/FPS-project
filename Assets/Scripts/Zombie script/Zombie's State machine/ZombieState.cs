

public abstract class ZombieState : State
{
    protected ZombieStateMachine zombieStateMachine;
    protected ZombieState(StateMachine stateMachine) : base(stateMachine)
    {
        zombieStateMachine = (ZombieStateMachine)stateMachine;
    }
}
