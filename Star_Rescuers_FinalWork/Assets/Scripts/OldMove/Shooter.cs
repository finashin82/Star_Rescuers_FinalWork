using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // Чем будет стрелять игрок
    [SerializeField] private GameObject _bullet;

    // Скорость стрельбы
    [SerializeField] private float fireSpeed;

    // Точка, откуда идет стрельба
    [SerializeField] private Transform firePoint;

    /// <summary>
    /// Стрельба, direction - направление
    /// </summary>
    /// <param name="direction"></param>
    public void Shoot(float direction)
    {
        // Создаем объект, которым будем стрелять. Quaternion.identity - без вращения
        GameObject currentBullet = Instantiate(_bullet, firePoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if(direction >= 0)
        {
            CurrentBulletVelocity(1);
        }
        else
        {
            CurrentBulletVelocity(-1);
        }

       void CurrentBulletVelocity(int leftOrRigth)
        {
            currentBulletVelocity.velocity = new Vector2(fireSpeed * leftOrRigth, currentBulletVelocity.velocity.y);
        }
    }

   
}
