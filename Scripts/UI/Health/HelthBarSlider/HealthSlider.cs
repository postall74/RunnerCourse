using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSlider : MonoBehaviour
{
    [SerializeField] private float _value;
    [SerializeField] private float _changedSpeed;

    private Slider _slider;
    private float _changedValue;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.value = _value;
        _changedValue = _value;
    }
    private void Update()
    {
        _slider.value = Mathf.MoveTowards(_value, _changedValue, _changedSpeed);
        _value = _changedValue;
    }

    public void OnValueChanged(float value)
    {
        _changedValue += value;
    }
}
