
using UnityEngine;

public class PlayerMovementApplier
{ 
    private Vector3 _velocity;

    private CharacterController _characterController;

    private PlayerHorizontalMovement _playerHorizontalMovement;
    private PlayerVerticalMovement _playerVerticalMovement;

    public PlayerMovementApplier(PlayerStateMachine playerStateMachine)
    {
        _characterController = playerStateMachine.GetComponent<CharacterController>();

        _playerHorizontalMovement = playerStateMachine.GetComponent<PlayerHorizontalMovement>();
        _playerVerticalMovement = playerStateMachine.GetComponent<PlayerVerticalMovement>();
    }

    public void ApplyMovement()
    {
        // Combine and apply horizontal and vertical velocities
        _velocity = new Vector3(_playerHorizontalMovement.horizontalVelocity.x,
                                _playerVerticalMovement.verticalVelocity,
                                _playerHorizontalMovement.horizontalVelocity.y);
        _characterController.Move(_velocity);
    }
}
