using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class HealthBarForButton : MonoBehaviour
{
    [SerializeField] private Button _healthUp;
    [SerializeField] private Button _healthDown;
    [SerializeField] private float _countHealthChange;
    [SerializeField] private HealthSlider _healthSlider;

    private void OnEnable()
    {
        _healthUp.onClick.AddListener(OnHealthUpButtonClick);
        _healthDown.onClick.AddListener(OnHealthDownButtonClick);
    }

    private void OnDisable()
    {
        _healthUp.onClick.RemoveListener(OnHealthUpButtonClick);
        _healthDown.onClick.RemoveListener(OnHealthDownButtonClick);
    }

    private void OnHealthUpButtonClick()
    {
        if (_healthSlider.TryGetComponent<Slider>(out Slider slider))
        {
            if (slider.value < 0.9999f)
            {
                _healthSlider.OnValueChanged(_countHealthChange);
            }
        }
    }

    private void OnHealthDownButtonClick()
    {
        if (_healthSlider.TryGetComponent<Slider>(out Slider slider))
        {
            if (slider.value > 0.0001f)
            {
                _healthSlider.OnValueChanged(-_countHealthChange);
            }
        }
    }
}
