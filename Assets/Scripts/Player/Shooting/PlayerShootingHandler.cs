
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingHandler
{
    private float _firingTimer;

    private PlayerInfo _playerInfo;
    private Transform _cameraTransform;
    private PlayerInput _playerInput;
    private InputAction _shootAction;

    public static event Action OnShoot;

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
            if (hit.transform.gameObject.tag == "Wall" || hit.transform.gameObject.tag == "Floor")
            {
                ObjectPoolManager.instance.TakeFromPool(_playerInfo.bulletHolePrefab,
                                                    hit.point + (hit.normal * 0.001f),
                                                    Quaternion.LookRotation(-hit.normal),
                                                    GameObject.FindWithTag("BulletHoleHolder").transform);
            }
            else if (hit.transform.tag == "Zombie")
            {
                hit.transform.gameObject.GetComponent<ZombieInfo>().TakeDamage(_playerInfo.gunDamage);
            }
        }
        OnShoot?.Invoke();
        _firingTimer = 0;
    }

    private void OnSingleShot(InputAction.CallbackContext context)
    {
        Shoot();
    }
}
