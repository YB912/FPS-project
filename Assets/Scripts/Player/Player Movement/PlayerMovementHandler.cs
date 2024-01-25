
using UnityEngine;

public class PlayerMovementHandler
{ 
    private Vector3 _velocity;

    private CharacterController _characterController;

    private PlayerHorizontalMovement _playerHorizontalMovement;
    private PlayerVerticalMovement _playerVerticalMovement;

    public PlayerMovementHandler(PlayerStateMachine playerStateMachine)
    {
        _characterController = playerStateMachine.GetComponent<CharacterController>();

        _playerHorizontalMovement = new PlayerHorizontalMovement(playerStateMachine);
        _playerVerticalMovement = new PlayerVerticalMovement(playerStateMachine);
    }

    public void Update()
    {
        _velocity = new Vector3(_playerHorizontalMovement.horizontalVelocity.x,
                                _playerVerticalMovement.verticalVelocity,
                                _playerHorizontalMovement.horizontalVelocity.y);
    }

    public void Apply()
    { 
        _characterController.Move(_velocity);
    }
}
