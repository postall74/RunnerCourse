using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private HealthIcon _healthTemplate;

    private List<HealthIcon> _healthIcons = new List<HealthIcon>();

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_healthIcons.Count < value)
        {
            int createHelthIcons = value - _healthIcons.Count;

            for (int i = 0; i < createHelthIcons; i++)
            {
                CreateHealthIcon();
            }
        }
        else if(_healthIcons.Count > value && _healthIcons.Count != 0)
        {
            int removeHealthIcons = _healthIcons.Count - value;

            for (int i = 0; i < removeHealthIcons; i++)
            {
                DestroyHealthIcon(_healthIcons[_healthIcons.Count - 1]);
            }
        }
    }

    private void DestroyHealthIcon(HealthIcon healthIcon)
    {
        _healthIcons.Remove(healthIcon);
        healthIcon.ToEmpty();
    }

    private void CreateHealthIcon()
    {
        HealthIcon newHealthIcon = Instantiate(_healthTemplate, transform);
        _healthIcons.Add(newHealthIcon.GetComponent<HealthIcon>());
        newHealthIcon.ToFill();
    }
}
