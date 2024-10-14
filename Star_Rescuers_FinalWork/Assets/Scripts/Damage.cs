using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Урон от пули
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Если у объекта есть скрипт с жизнью, то можем нанести ему урон
        if (collision.gameObject.TryGetComponent<Health>(out var health))
        {
            // У объекта с которым столкнулись пули, вызывается скрипт "Health" и метод "TakeDamage" с параметром damage (Уменьшает здоровье)
            health.TakeDamage(damage);
        }
    }
}
