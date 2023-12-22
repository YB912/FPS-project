
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Singleton<PlayerMovement> 
{
    [SerializeField] private float _defaultWalkingSpeed;

    private Vector2 _currentMovementInput;
    private Vector3 _playerVelocity;

    private CharacterController _characterController;
    // private playerStateMachine _playerStateMachine;
    private PlayerInput _playerInput;
    private InputAction _movementAction;
    
    public float defaultWalkingSpeed { get => _defaultWalkingSpeed; private set => _defaultWalkingSpeed = value; }

    protected override void Awake()
    {
        base.Awake();
        _characterController = GetComponent<CharacterController>();
    }

    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _movementAction = _playerInput.actions["Movement"];
    }

    private void Update()
    {
        // if ((_playerStateMachine.state is PlayerDeadState) == false) ...
        _currentMovementInput = _movementAction.ReadValue<Vector2>();
        if (_currentMovementInput != Vector2.zero)
        {
            ProcessMovement(_currentMovementInput); // Calculate movement
        }
        else
        {
            _playerVelocity = new Vector3(0, _playerVelocity.y, 0);
        }
    }

    private void FixedUpdate()
    {
        _characterController.Move(_playerVelocity); // Apply movement
    }

    private void ProcessMovement(Vector2 input)
    {
        // if ((_playerStateMachine.state is PlayerDeadState) == false) ...
        var movementVector = Vector3.zero;
        movementVector.x = input.x;
        movementVector.z = input.y;
        _playerVelocity = transform.TransformDirection(movementVector) * defaultWalkingSpeed * Time.deltaTime;
    }
}
