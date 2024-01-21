
using UnityEngine;

public interface IState
{
    public IStateMachine stateMachine { get; }

    public void Update();

    public void FixedUpdate();

    public void OnExit();

    public void OnEnter();
}
