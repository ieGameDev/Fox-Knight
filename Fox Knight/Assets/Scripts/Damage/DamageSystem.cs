using System;
using UnityEngine;

public abstract class DamageSystem : MonoBehaviour
{
    [SerializeField] protected int _maxHealth;
    [SerializeField] protected int _currentHealth;

    public int CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    protected abstract void Dead();
    protected abstract void Damage();
    protected abstract void StopTakingDamage();

    public event Action<float> HealthChanged;

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            HealthChanged?.Invoke(0);
            Dead();
        }
        else if (damage > 5)
        {
            Damage();
            float currentHealthAsPercentage = (float)_currentHealth / _maxHealth;
            HealthChanged?.Invoke(currentHealthAsPercentage);
        }
    }

    public void ApplyHeal(int heal)
    {
        _currentHealth = heal;
        HealthChanged?.Invoke(heal);
    }

    public void ÑompleteTakeDamage()
    {
        StopTakingDamage();
    }
}
