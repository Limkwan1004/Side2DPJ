using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour, IHealthObserver
{
    [SerializeField] private Slider _healthSlider;

    public void OnHealthChanged(float newHealth)
    {
        _healthSlider.value = newHealth;
    }
}
