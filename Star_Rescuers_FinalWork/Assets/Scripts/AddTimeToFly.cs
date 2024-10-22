using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTimeToFly : MonoBehaviour
{
    [SerializeField] private float _time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<TimeToFly>(out var timeToFly))
        {
            // У объекта с которым столкнулись пули, вызывается скрипт "Health" и метод "TakeDamage" с параметром damage (Уменьшает здоровье)
            timeToFly.AddTimeToFly(_time);
        }
    }
}
