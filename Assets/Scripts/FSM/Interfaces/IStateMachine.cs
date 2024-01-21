

public interface IStateMachine
{
    public IState currentState { get; }

    public void ChangeState(IState newState);
    public void Update();
    public void FixedUpdate();
}
