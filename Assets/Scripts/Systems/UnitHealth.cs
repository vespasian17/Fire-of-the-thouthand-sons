using System;
using UnityEngine;

public class UnitHealth
{
    private int _currentHealth;
    private int _currentMaxHealth;

    public int Health
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, 0, _currentMaxHealth);
    }

    public int MaxHealth
    {
        get => _currentMaxHealth;
        set => _currentMaxHealth = Mathf.Max(0, value);
    }

    public UnitHealth(int health, int maxHealth)
    {
        _currentMaxHealth = Mathf.Max(0, maxHealth);
        _currentHealth = Mathf.Clamp(health, 0, _currentMaxHealth);
    }

    public void TakeDamage(int damageAmount)
    {
        if (damageAmount < 0) throw new ArgumentOutOfRangeException(nameof(damageAmount), "Damage amount cannot be negative");
        if (_currentHealth > 0)
        {
            _currentHealth -= damageAmount;
            _currentHealth = Mathf.Max(0, _currentHealth);
        }
    }

    public void TakeHeal(int healAmount)
    {
        if (healAmount < 0) throw new ArgumentOutOfRangeException(nameof(healAmount), "Heal amount cannot be negative");
        if (_currentHealth < _currentMaxHealth)
        {
            _currentHealth += healAmount;
            _currentHealth = Mathf.Min(_currentHealth, _currentMaxHealth);
        }
    }
}