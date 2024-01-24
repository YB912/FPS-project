
using UnityEngine;

public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private float _mouseSensitivity = 100f;

    [SerializeField] private float _defaultWalkingSpeed = 10f;

    [SerializeField, Range(0f, 1f)] private float _jumpForce = 0.7f;
    [SerializeField] private float _gravityGrowth = -100f;

    [SerializeField, Range(8f, 20f)] private float _fireRate = 1f;
    [SerializeField] private float _gunRange = 100f;

    [SerializeField] private GameObject _bulletHolePrefab;

    public float mouseSensitivity { get => _mouseSensitivity; }

    public float defaultWalkingSpeed { get => _defaultWalkingSpeed; }

    public float jumpForce { get => _jumpForce; }
    public float gravityGrowth { get => _gravityGrowth; }

    public float fireRate { get => _fireRate; }
    public float gunRange { get => _gunRange; }

    public GameObject bulletHolePrefab { get => _bulletHolePrefab; }
}
