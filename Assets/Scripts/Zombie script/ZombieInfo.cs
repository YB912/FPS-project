
using UnityEngine;

public class ZombieInfo : MonoBehaviour, IDamageable
{
    [SerializeField] private float _zombieSpeed;

    [SerializeField] private float _attackDistance;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _damage;

    [SerializeField] private float _maximumHealth;

    public float zombieSpeed { get => _zombieSpeed; }

    public float attackDistance { get => _attackDistance; }
    public float attackSpeed {  get => _attackSpeed; }
    public float damage { get => _damage; }

    public float maximumHealth { get => _maximumHealth; }
    public float currentHealth { get; set; }

    private void Start()
    {
        currentHealth = maximumHealth;
    }

    public void LookAt(Vector3 pos)
    {
        transform.LookAt(pos);
    }

    public void TakeDamage(float damage)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        Debug.Log($"Zombie {gameObject} took {damage} amount of damage, HP left: {currentHealth}");
    }
}
