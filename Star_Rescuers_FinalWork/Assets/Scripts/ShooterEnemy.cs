using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
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

    private float timeShoot;

    private bool isFire;

    private Transform player;
   
    void Start()
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
                Shoot();

                Invoke("StopFireFlash", 0.2f);

                timeShoot = _timeShoot;
            }
        }
    }

    /// <summary>
    /// Выстрел
    /// </summary>
    public void Shoot()
    {        
        StartFireFlash();

        // Создаем объект, которым будем стрелять. Quaternion.identity - без вращения
        GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

        // Доступ к RigidBody2D объекта
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        // Стрельба префабом в том направлении куда направлен объект
        currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x, currentBulletVelocity.velocity.y);       
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFire = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFire = false;
        }
    }
}
