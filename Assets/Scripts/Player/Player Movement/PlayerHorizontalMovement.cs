
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHorizontalMovement
{
    private Vector2 _currentMovementInput;

    private Vector2 _horizontalVelocity;

    private PlayerInfo _playerInfo;
    private Transform _playerTransform;
    private PlayerInput _playerInput;
    private InputAction _movementAction;

    public Vector2 horizontalVelocity
    {
        get
        {
            ProcessHorizontalMovement();
            return _horizontalVelocity;
        }
        private set { _horizontalVelocity = value; }
    }

    public PlayerHorizontalMovement(PlayerStateMachine stateMachine)
    {
        _playerInfo = stateMachine.playerInfo;
        _playerTransform = stateMachine.transform;
        _playerInput = stateMachine.GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["Movement"];
    }

    private void ProcessHorizontalMovement()
    {
        _currentMovementInput = _movementAction.ReadValue<Vector2>();
        var movementX = _currentMovementInput.x * _playerTransform.right;
        var movementZ = _currentMovementInput.y * _playerTransform.forward;
        var direction3 = (movementX + movementZ).normalized;
        var direction2 = new Vector2(direction3.x, direction3.z);
        _horizontalVelocity = direction2 * _playerInfo.defaultWalkingSpeed * Time.deltaTime;
    }
}
