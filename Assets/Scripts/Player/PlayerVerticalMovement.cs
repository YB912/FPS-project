
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVerticalMovement : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float _jumpForce = -0.3f;
    [SerializeField] private float _gravityGrowth = -80f;

    private CharacterController _characterController;
    private PlayerInput _playerInput;
    private InputAction _jumpAction;

    public float _verticalVelocity { get; private set; }

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
        _jumpAction = _playerInput.actions["Jump"];

        _jumpAction.performed += Jump;
    }

    public void ProcessGravity()
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
