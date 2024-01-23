

public class PlayerStateMachine : StateMachine
{
    public PlayerMovementApplier playerMovement {  get; private set; }
    private void Start()
    {
        currentState = new PlayerLocomotionState(this);
        playerMovement = new PlayerMovementApplier(this);
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

}
