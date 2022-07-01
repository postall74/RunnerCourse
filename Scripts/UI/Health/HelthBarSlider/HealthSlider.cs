using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthSlider : MonoBehaviour
{
    [SerializeField] private float _value;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    public void OnValueChanged(float value)
    {
        _value += value;
        _slider.value = _value;
    }

}
