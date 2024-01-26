
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerVerticalMovement
{
    private float _verticalVelocity;

    private PlayerInfo _playerInfo;
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

    public PlayerVerticalMovement(PlayerStateMachine stateMachine)
    {
        _playerInfo = stateMachine.playerInfo;
        _characterController = stateMachine.GetComponent<CharacterController>();
        _playerInput = stateMachine.GetComponent<PlayerInput>();
        _jumpAction = _playerInput.actions["Jump"];

        _jumpAction.performed += Jump;
    }

    private void ProcessGravity()
    {
        if (_characterController.isGrounded == false)
        {
            _verticalVelocity += _playerInfo.gravityGrowth * Time.deltaTime;
        }
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (_characterController.isGrounded)
        {
            _verticalVelocity = _playerInfo.jumpForce;
            AudioManager.instance.PlaySound(AudioManager.Type.PLAYER_JUMP, PlayerInfo.instance.GetComponent<AudioSource>(), 1);
        }
    }
}
