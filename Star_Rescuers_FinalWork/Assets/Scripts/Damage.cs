using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // ���� �� ����
    [SerializeField] private float _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� � ������� ���� ������ � ������, �� ����� ������� ��� ����
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            // � ������� � ������� ����������� ����, ���������� ������ "Health" � ����� "TakeDamage" � ���������� damage (��������� ��������)
            health.TakeDamage(_damage);
        }

        // ����������� ���� ��� ������������ � ��������� �����, ������ ��� �����
        if (collision.CompareTag("Enemy") || collision.CompareTag("Ground") || collision.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
