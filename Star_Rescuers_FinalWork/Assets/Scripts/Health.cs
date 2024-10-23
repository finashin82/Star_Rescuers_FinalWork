using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Максимальная жизнь
    [SerializeField] private float _maxHealth;

    // Текущая жизнь
    private float currentHealth;

    [SerializeField] private UnityEvent<Health> healthEvent;
       
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => currentHealth;
    public bool IsAlive => currentHealth > 0;

    private void Awake()
    {
        currentHealth = _maxHealth;        
    }

    /// <summary>
    /// Урон игроку
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
       
        healthEvent?.Invoke(this);

        Debug.Log($"{currentHealth}");
    }

    /// <summary>
    /// Увеличение здоровья
    /// </summary>
    /// <param name="health"></param>
    public void AddHealth(float health)
    {
        currentHealth += health;

        if (currentHealth > MaxHealth)
        {
            currentHealth = MaxHealth;
        }
    }
}
