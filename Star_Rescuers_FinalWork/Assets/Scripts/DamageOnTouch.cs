using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    [SerializeField] private float _damageOnTouch;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Если у объекта есть скрипт с жизнью, то можем нанести ему урон
        if (collision.gameObject.TryGetComponent<Health>(out var health) && collision.gameObject.CompareTag("Player"))
        {
            // У объекта с которым столкнулись пули, вызывается скрипт "Health" и метод "TakeDamage" с параметром damage (Уменьшает здоровье)
            health.TakeDamage(_damageOnTouch);            
        }
    }
}
