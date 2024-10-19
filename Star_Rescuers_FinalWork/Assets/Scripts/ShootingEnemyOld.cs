using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyOld : MonoBehaviour
{
    //private Shooting shot;

    // Чем будет стрелять игрок
    [SerializeField] private GameObject _bulletPrefab;

    // Скорость стрельбы
    [SerializeField] private float _fireSpeed;

    // Точка, откуда идет стрельба
    [SerializeField] private Transform _firePoint;

    // Вспышка от выстрела
    [SerializeField] private GameObject _fireFlash;

    // Время между стрельбой
    [SerializeField] private float _timeShoot;   

    // Время между стрельбой
    private float timeShoot;

    // Разрешение на выстрел
    private bool isFire;

    private Transform player;

    private void Awake()
    {
        //shot = GetComponent<Shooting>();

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

                //shot.Shot(_bulletPrefab, _firePoint, _fireSpeed);

                Invoke("StopFireFlash", 0.2f);

                timeShoot = _timeShoot;
            }
        }
    }

    /// <summary>
    /// Убрать вспышку выстрела
    /// </summary>
    private void StopFireFlash()
    {
        _fireFlash.SetActive(false);
    }

    /// <summary>
    /// Показать вспышку выстрела
    /// </summary>
    private void StartFireFlash()
    {
        _fireFlash.SetActive(true);
    }

    /// <summary>
    /// Поворот Enemy в сторону игрока
    /// </summary>
    private void DirectionOfThePlayer()
    {
        Vector3 playerPos = player.position;
        Vector3 enemyPos = transform.position;

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
