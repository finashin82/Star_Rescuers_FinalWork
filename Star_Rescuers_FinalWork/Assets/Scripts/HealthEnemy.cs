using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HealthEnemy : MonoBehaviour
{
    // ������������ �����
    [SerializeField] private float _maxHealth;

    // ������� �����
    private float currentHealth;

    [SerializeField] private UnityEvent<HealthEnemy> healthEvent;
       
    public float MaxHealth => _maxHealth;
    public float CurrentHealth => currentHealth;
    public bool IsAlive => currentHealth > 0;

    private void Awake()
    {
        currentHealth = _maxHealth;        
    }

    /// <summary>
    /// ���� ������
    /// </summary>
    /// <param name="damage"></param>
    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;

        healthEvent?.Invoke(this);
    }   
}
