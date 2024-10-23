using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddMaxTimeToFly : MonoBehaviour
{
    [SerializeField] private float _addMaxTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<FlyPlayer>(out var timeToFly))
        {
            // У объекта с которым столкнулись пули, вызывается скрипт "Health" и метод "TakeDamage" с параметром damage (Уменьшает здоровье)
            timeToFly.AddMaxTimeToFly(_addMaxTime);

            gameObject.SetActive(false);
        }
    }
}
