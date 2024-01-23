
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVerticalMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _jumpForce = 0.5f;
    [SerializeField] private float _gravityGrowth = -200f;

    private float _verticalVelocity;

    private CharacterController _characterController;
    private PlayerInput _playerInput;
    private InputAction _jumpAction;

    public float verticalVelocity
    {
        get
        {
            ProcessGravity();
            return _verticalVelocity;
        }
        set { _verticalVelocity = value; }
    }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _jumpAction = _playerInput.actions["Jump"];

        _jumpAction.performed += Jump;
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
