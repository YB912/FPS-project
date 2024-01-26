
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public PlayerInfo playerInfo { get; private set; }
    public PlayerMovementHandler playerMovement {  get; private set; }
    public PlayerLookHandler playerLook {  get; private set; }
    public PlayerShootingHandler playerShooting { get; private set; }

    private void Start()
    {
        currentState = new PlayerLocomotionState(this);
        playerInfo = GetComponent<PlayerInfo>();
        playerMovement = new PlayerMovementHandler(this);
        playerLook = new PlayerLookHandler(this);
        playerShooting = new PlayerShootingHandler(this);
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (currentState is PlayerAirborneState)
        {
            var airborneState = currentState as PlayerAirborneState;
            airborneState.OnControllerCollisionHit(hit);
        }
    }
}
