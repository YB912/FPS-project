
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHorizontalMovement : MonoBehaviour
{
    [SerializeField] private float _defaultWalkingSpeed = 30f;

    private Vector2 _currentMovementInput;

    private PlayerInput _playerInput;
    private InputAction _movementAction;

    public float defaultWalkingSpeed { get => _defaultWalkingSpeed; private set => _defaultWalkingSpeed = value; }

    public Vector2 horizontalVelocity { get; private set; }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["Movement"];
    }

    public void ProcessHorizontalMovement()
    {
        _currentMovementInput = _movementAction.ReadValue<Vector2>();
        var movementX = _currentMovementInput.x * transform.right;
        var movementZ = _currentMovementInput.y * transform.forward;
        var direction3 = (movementX + movementZ).normalized;
        var direction2 = new Vector2(direction3.x, direction3.z);
        horizontalVelocity = direction2 * defaultWalkingSpeed * Time.deltaTime;
    }
}
