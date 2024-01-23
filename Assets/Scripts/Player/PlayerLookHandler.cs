

using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerLookHandler
{
    private float _horizontalRotation;
    private float _verticalRotation;

    private PlayerInfo _playerInfo;
    private Transform _playerTransform;
    private Transform _cameraTransform;
    private PlayerInput _playerInput;
    private InputAction _lookAction;

    public PlayerLookHandler(PlayerStateMachine stateMachine)
    {
        _playerInfo = stateMachine.playerInfo;
        _playerTransform = stateMachine.transform;
        _cameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        _playerInput = stateMachine.GetComponent<PlayerInput>();
        _lookAction = _playerInput.actions["Look"];
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        var currentInput = _lookAction.ReadValue<Vector2>();
        ProcessRotations(currentInput);
    }

    public void Apply()
    {
        _playerTransform.Rotate(Vector3.up, _horizontalRotation);
        _cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);
    }

    private void ProcessRotations(Vector2 input)
    {
        _horizontalRotation = input.x * _playerInfo.mouseSensitivity * Time.deltaTime;
        _verticalRotation -= input.y * (_playerInfo.mouseSensitivity / 2) * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -70, 70);
    }
}
