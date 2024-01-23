

using UnityEngine;

public abstract class State : IState
{
    public StateMachine stateMachine { get; protected set; }

    public State(StateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }

    public abstract void FixedUpdate();

    public abstract void Update();

    public abstract void OnExit();

    public abstract void OnEnter();

    protected T GetComponent<T>()
    {
        return stateMachine.GetComponent<T>();
    }
}
