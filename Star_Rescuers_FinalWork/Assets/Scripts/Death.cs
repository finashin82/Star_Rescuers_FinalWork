using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animatorGamer;

    private Rigidbody2D rb;

    private GameObject gb;

    private Shooting shooting;

    private BoxCollider2D collider2d;

    private void Awake()
    {
        animatorGamer = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        collider2d = GetComponent<BoxCollider2D>();

        gb = GetComponent<GameObject>();

        shooting = GetComponent<Shooting>();
    }

    /// <summary>
    /// Анимация смерти и смерть игрока
    /// </summary>
    /// <param name="health"></param>
    public void DeathPlayer(Health health)
    {
        // Если текущая жизнь меньше или равна 0, то запуск анимации и скрытие объекта
        if (!health.IsAlive)
        { 
            // Выключаем скрипт стрельбы
            shooting.enabled = false;

            // Перевод RigidBody2D в режим кинематики
            rb.isKinematic = true;            

            // Отключаем коллайдер
            collider2d.enabled = false;

            animatorGamer.SetBool("isDeath", true);            

            Invoke("DestroyObject", 1f);
        }
    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
