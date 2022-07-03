using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _minHealth = 0;
    [SerializeField] private int _changeHealth = 10;

    private int _health;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public int ChangeHealth => _changeHealth;
    public int CurrentHealth => _health;

    public event UnityAction<int> HealthChanged;
    public event UnityAction Died;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void TakeDamage()
    {
        _health = Mathf.Clamp(_health - _changeHealth, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void TakeDamage(int damage)
    {
        _health -= Mathf.Clamp(_health - damage, _minHealth, _maxHealth); ;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
            Die();
    }

    public void TakeHealth()
    {
        _health = Mathf.Clamp(_health + _changeHealth, _minHealth, _maxHealth);
        HealthChanged?.Invoke(_health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
