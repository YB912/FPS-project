

public interface IStateMachine
{
    public IState currentState { get; }

    public void ChangeState(IState newState);
}
