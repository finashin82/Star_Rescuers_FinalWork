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

    private Transform player;

    private float timeShoot, direction;

    private bool isFire;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeShoot = _timeShoot;
        isFire = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.transform.localScale - transform.position;

        direction.Normalize();

        //transform.localScale = new Vector2(direction, 1);

        transform.LookAt(player);

        //transform.position = direction;

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

    public void Shoot()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            StartFireFlash();

            // Создаем объект, которым будем стрелять. Quaternion.identity - без вращения
            GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

            // Доступ к RigidBody2D объекта
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            // Стрельба префабом в том направлении куда направлен объект
            currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x * direction, currentBulletVelocity.velocity.y);
        //}
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
