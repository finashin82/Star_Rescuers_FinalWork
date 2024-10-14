using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // ������������ �����
    [SerializeField] private float maxHealth;

    // ������� �����
    private float currentHealth;

    [SerializeField] private UnityEvent<Health> healthEvent;
       
    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public bool IsAlive => currentHealth > 0;

    private void Awake()
    {
        currentHealth = maxHealth;        
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
