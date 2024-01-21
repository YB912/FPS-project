
using UnityEngine;

public abstract class StateMachine : IStateMachine
{
    public IState currentState { get; private set; }

    public virtual void ChangeState(IState newState)
    {
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }
    public abstract void Update();

    public abstract void FixedUpdate();
}
