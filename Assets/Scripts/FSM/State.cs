

public abstract class State : IState
{
    public IStateMachine stateMachine { get; protected set; }

    public State(IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public abstract void FixedUpdate();

    public abstract void Update();

    public abstract void OnExit();

    public abstract void OnEnter();
}
