using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private float _addHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            // У объекта с которым столкнулись, есть жизни, то добавляем
            health.AddHealth(_addHealth);

            gameObject.SetActive(false);
        }
    }
}
