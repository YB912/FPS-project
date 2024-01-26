
using UnityEngine;

public class PlayerInfo : Singleton<PlayerInfo>, IDamageable
{
    [SerializeField] private float _mouseSensitivity = 10f;

    [SerializeField] private float _defaultWalkingSpeed = 30f;

    [SerializeField, Range(0f, 10f)] private float _jumpForce = 1f;
    [SerializeField] private float _gravityGrowth = -20f;

    [SerializeField, Range(8f, 20f)] private float _fireRate = 1f;
    [SerializeField] private float _gunRange = 100f;

    [SerializeField] private float _gunDamage;
    [SerializeField] private float _jumpDamage;

    [SerializeField] private float _maximumHealth;

    [SerializeField] private GameObject _bulletHolePrefab;

    public float mouseSensitivity { get => _mouseSensitivity; }

    public float defaultWalkingSpeed { get => _defaultWalkingSpeed; }

    public float jumpForce { get => _jumpForce; }
    public float gravityGrowth { get => _gravityGrowth; }

    public float fireRate { get => _fireRate; }
    public float gunRange { get => _gunRange; }

    public float gunDamage { get => _gunDamage; }
    public float jumpDamage { get => _jumpDamage; }

    public float maximumHealth { get => _maximumHealth; }

    public float currentHealth { get; set; }

    public GameObject bulletHolePrefab { get => _bulletHolePrefab; }

    private void Start()
    {
        currentHealth = maximumHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Debug.Log($"Player took {damage} amount of damage, HP left: {currentHealth}");
    }
}
