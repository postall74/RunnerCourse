using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _minHealth = 0;

    private int _health;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public int CurrentHealth => _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage(int damage)
    {
        _health = Mathf.Clamp(_health - damage, _minHealth, _maxHealth); ;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void TakeHealth(int health)
    {
        _health = Mathf.Clamp(_health + health, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
