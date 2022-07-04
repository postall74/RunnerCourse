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

    private void Start() => _healthSlider = GetComponent<Slider>();

    private void OnHealthChanged(int health)
    {
        if (_coroutineHealthChanged != null)
            StopCoroutine(_coroutineHealthChanged);

        _coroutineHealthChanged = StartCoroutine(HealthChange(health));
    }

    private IEnumerator HealthChange(float targetHealth)
    {
        float normalizeTargetHealth = targetHealth / _player.MaxHealth;

        while (_healthSlider.value != normalizeTargetHealth)
        {
            _healthSlider.value = Mathf.MoveTowards(_healthSlider.value, normalizeTargetHealth, _speedChange * Time.deltaTime);
            yield return null;
        }
    }
}

