
using UnityEngine;

public abstract class StateMachine : MonoBehaviour, IStateMachine
{
    public IState currentState { get; protected set; }

    public virtual void ChangeState(IState newState)
    {
        currentState.OnExit();
        currentState = newState;
        currentState.OnEnter();
    }
}
