using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Shooting
{
    [SerializeField] private AudioSource _soundShooting;

    // Время между стрельбой
    [SerializeField] private float _timeShoot;   

    // Время между стрельбой
    private float timeShoot;

    // Разрешение на выстрел
    private bool isFire;

    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
                
        timeShoot = _timeShoot;

        isFire = false;
    }
       
    void Update()
    {
        DirectionOfThePlayer();

        if (isFire)
        {
            timeShoot -= Time.deltaTime;

            if (timeShoot <= 0)
            {               
                StartFireFlash();

                _soundShooting.Play();

                Shot();
               
                Invoke("StopFireFlash", 0.2f);

                timeShoot = _timeShoot;
            }
        }
    }   

    /// <summary>
    /// Поворот Enemy в сторону игрока
    /// </summary>
    private void DirectionOfThePlayer()
    {
        Vector2 playerPos = player.position;
        Vector2 enemyPos = transform.position;

        if (playerPos.x < enemyPos.x) // игрок находится слева от врага
        {
            transform.localScale = new Vector2(-1, 1); // поворачиваем врага влево
        }
        else // игрок находится справа от врага
        {
            transform.localScale = new Vector2(1, 1); // поворачиваем врага вправо
        }
    }

    // При входе в триггер начинается стрельба
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFire = true;
        }
    }

    // При выходе из триггера стрельба прекращается
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFire = false;
        }
    }
}
