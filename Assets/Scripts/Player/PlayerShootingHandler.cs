
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingHandler
{

    private float _firingTimer;

    private PlayerInfo _playerInfo;
    private Transform _cameraTransform;
    private PlayerInput _playerInput;
    private InputAction _shootAction;


    public PlayerShootingHandler(PlayerStateMachine stateMachine)
    {
        _playerInfo = stateMachine.playerInfo;
        _cameraTransform = GameObject.FindWithTag("MainCamera").GetComponent<Transform>();
        _playerInput = stateMachine.GetComponent<PlayerInput>();
        _shootAction = _playerInput.actions["Shoot"];

        _shootAction.started += OnSingleShot;
    }

    public void Update()
    {
        if (_shootAction.ReadValue<float>() == 1)
        {
            _firingTimer += Time.deltaTime;
            if (_firingTimer >= 1 / _playerInfo.fireRate)
            {
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out hit, _playerInfo.gunRange))
        {
            Debug.Log($"{hit.transform.name} was shot.");
        }
        _firingTimer = 0;
    }

    private void OnSingleShot(InputAction.CallbackContext context)
    {
        Shoot();
    }
}
