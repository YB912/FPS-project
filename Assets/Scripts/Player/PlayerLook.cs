
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity;

    private float _horizontalRotation;
    private float _verticalRotation;

    private Transform _cameraTransform;
    private PlayerInput _playerInput;
    private InputAction _lookAction;

    private void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _lookAction = _playerInput.actions["Look"];
    }

    private void Start()
    {
        _cameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        var currentInput = _lookAction.ReadValue<Vector2>();
        ProcessRotation(currentInput);
    }

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up, _horizontalRotation);
        _cameraTransform.localRotation = Quaternion.Euler(_verticalRotation, 0, 0);
    }

    private void ProcessRotation(Vector2 input)
    {
        _horizontalRotation = input.x * _mouseSensitivity * Time.deltaTime;
        _verticalRotation -= input.y * (_mouseSensitivity / 2) * Time.deltaTime;
        _verticalRotation = Mathf.Clamp(_verticalRotation, -70, 70);
    }
}
