
using UnityEngine;

public interface IDamageable
{
    public float currentHealth { get; }
    public float maximumHealth { get; }

    public void TakeDamage(float damage);

    public virtual void Heal(float amount) { }
}
