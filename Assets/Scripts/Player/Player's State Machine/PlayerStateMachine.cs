

public class PlayerStateMachine : StateMachine
{
    public override void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    public override void Update()
    {
        currentState.Update();
    }
}
