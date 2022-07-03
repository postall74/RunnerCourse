using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;

    private readonly float _speedChange = 0.5f;
    private Coroutine _coroutineHealthChanged;
    private Slider _healthSlider;

    private void OnEnable() => _player.HealthChanged += OnHealthChanged;

    private void OnDisable() => _player.HealthChanged -= OnHealthChanged;

    private void Start()
    {
        _healthSlider = GetComponent<Slider>();
    }

    private void OnHealthChanged(int health)
    {
        if (_healthSlider != null && _coroutineHealthChanged != null)
        {
            StopCoroutine(HealthChange(health));
            _coroutineHealthChanged = null;
        }

        _coroutineHealthChanged = StartCoroutine(HealthChange(health));
    }

    private IEnumerator HealthChange(float targetHealth)
    {
        float normalizeTargetHealth = targetHealth / _player.MaxHealth;
        float normalizeCurrentHealth = _healthSlider.value;

        while (normalizeCurrentHealth != normalizeTargetHealth)
        {
            normalizeCurrentHealth = Mathf.MoveTowards(_healthSlider.value, normalizeTargetHealth, _speedChange * Time.deltaTime);
            _healthSlider.value = normalizeCurrentHealth;
            yield return null;
        }

    }
}

