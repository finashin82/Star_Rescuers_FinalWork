using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCurrentTimeToFly : MonoBehaviour
{
    [SerializeField] private float _addCurrentTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<FlyPlayer>(out var timeToFly))
        {
            // У объекта, который взял энергию, вызывается скрипт добавления энергии 
            timeToFly.AddCurrentTimeToFly(_addCurrentTime);

            gameObject.SetActive(false);
        }
    }
}
