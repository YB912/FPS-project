
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : Singleton<PlayerMovement> 
{
    [SerializeField] private float _defaultWalkingSpeed = 30f;
    [SerializeField, Range(0f, 1f)] private float _jumpForce = -0.3f;
    [SerializeField] private float _gravityGrowth = -80f;

    private float _verticalVelocity;
    private Vector2 _horizontalVelocity;
    private Vector3 _velocity;
    private Vector2 _currentMovementInput;

    private CharacterController _characterController;
    // private playerStateMachine _playerStateMachine;
    private PlayerInput _playerInput;
    private InputAction _movementAction;
    private InputAction _jumpAction;
    
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
        _jumpAction = _playerInput.actions["Jump"];

        _jumpAction.performed += Jump;
    }

    private void Update()
    {
        // if ((_playerStateMachine.state is PlayerDeadState) == false) ...
        _currentMovementInput = _movementAction.ReadValue<Vector2>();

        ProcessHorizontalMovement(_currentMovementInput);
        
        ProcessGravity();
    }

    private void FixedUpdate()
    {
        _velocity = new Vector3(_horizontalVelocity.x, _verticalVelocity, _horizontalVelocity.y);
        _characterController.Move(_velocity); // Apply movement
    }

    private void ProcessHorizontalMovement(Vector2 input)
    {
        // if ((_playerStateMachine.state is PlayerDeadState) == false) ...
        var movementX = input.x * transform.right;
        var movementZ = input.y * transform.forward;
        var direction3 = (movementX + movementZ).normalized;
        var direction2 = new Vector2(direction3.x, direction3.z);
        _horizontalVelocity = direction2 * defaultWalkingSpeed * Time.deltaTime;      
    }

    private void ProcessGravity()
    {
        if (_characterController.isGrounded == false)
        {
            _verticalVelocity += _gravityGrowth * Time.deltaTime * Time.deltaTime;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = _jumpForce;
        }
    }
}
