using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingPoolObject : MonoBehaviour
{
    // Чем будет стрелять игрок
    //[SerializeField] private GameObject _bulletPrefab;

    //// Скорость стрельбы
    //[SerializeField] private float _fireSpeed;

    // Точка, откуда идет стрельба
    [SerializeField] private Transform _firePoint;

    // Вспышка от выстрела
    [SerializeField] private GameObject _fireFlash;

    /// <summary>
    /// Стрельба
    /// </summary>
    /// <param name="bulletPrefab"></param>
    /// <param name="firePoint"></param>
    /// <param name="fireSpeed"></param>
    public void Shot()
    {
        // Создаем объект, которым будем стрелять. Quaternion.identity - без вращения
        //GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

        // Доступ к RigidBody2D объекта
        //Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        //// Стрельба префабом в том направлении куда направлен объект
        //currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x, currentBulletVelocity.velocity.y);
    }    
}
