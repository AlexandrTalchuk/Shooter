using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] private float _maxHealth = 100f;
    private float _currentHealth;

    private void Start()
    {
       _currentHealth=_maxHealth;
        _healthBar.SetMaxHealth(_maxHealth);
    }
    public void TakeDamage(float value)
    {
        _currentHealth -= value;
        _healthBar.SetHealth(_currentHealth);
        if(_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
