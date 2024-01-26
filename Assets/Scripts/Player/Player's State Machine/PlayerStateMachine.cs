
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStateMachine : StateMachine
{
    private float _kickTimer;

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

        AudioManager.instance.PlaySound(AudioManager.Type.PULL_WEAPON, GetComponent<AudioSource>(), 1);
    }

    private void Update()
    {
        currentState.Update();

        if (_kickTimer < PlayerInfo.instance.kickCooldown)
        {
            _kickTimer += Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (currentState is PlayerAirborneState && _kickTimer >= PlayerInfo.instance.kickCooldown)
        {
            var airborneState = currentState as PlayerAirborneState;
            airborneState.OnControllerCollisionHit(hit);
            _kickTimer = 0;
        }
    }
}
