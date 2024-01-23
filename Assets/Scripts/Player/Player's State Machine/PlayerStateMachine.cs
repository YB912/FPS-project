

public class PlayerStateMachine : StateMachine
{
    public PlayerInfo playerInfo { get; private set; }
    public PlayerMovementHandler playerMovement {  get; private set; }
    public PlayerLookHandler playerLook {  get; private set; }
    private void Start()
    {
        currentState = new PlayerLocomotionState(this);
        playerInfo = GetComponent<PlayerInfo>();
        playerMovement = new PlayerMovementHandler(this);
        playerLook = new PlayerLookHandler(this);
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
