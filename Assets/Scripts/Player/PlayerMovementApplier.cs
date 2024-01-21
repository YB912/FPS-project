
using UnityEngine;

public class PlayerMovementApplier : MonoBehaviour
{
    private Vector3 _velocity;

    private CharacterController _characterController;

    private PlayerHorizontalMovement _playerHorizontalMovement;
    private PlayerVerticalMovement _playerVerticalMovement;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();

        _playerHorizontalMovement = GetComponent<PlayerHorizontalMovement>();
        _playerVerticalMovement = GetComponent<PlayerVerticalMovement>();
    }

    public void ApplyMovement()
    {
        _playerHorizontalMovement.ProcessHorizontalMovement();
        _playerVerticalMovement.ProcessGravity();

        _velocity = new Vector3(_playerHorizontalMovement.horizontalVelocity.x,
                                _playerVerticalMovement._verticalVelocity,
                                _playerHorizontalMovement.horizontalVelocity.y);
        _characterController.Move(_velocity); // Apply movement
    }
}
