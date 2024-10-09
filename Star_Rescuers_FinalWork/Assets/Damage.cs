using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // ���� �� ����
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� � ������� ���� ������ � ������, �� ����� ������� ��� ����
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            // � ������� � ������� ����������� ����, ���������� ������ "Health" � ����� "TakeDamage" � ���������� damage (��������� ��������)
            health.TakeDamage(damage);
        }
    }
}
