using UnityEngine;

public class ShooterPlayer : MonoBehaviour
{
    // Чем будет стрелять игрок
    [SerializeField] private GameObject _bulletPrefab;

    // Скорость стрельбы
    [SerializeField] private float _fireSpeed;

    // Точка, откуда идет стрельба
    [SerializeField] private Transform _firePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Создаем объект, которым будем стрелять. Quaternion.identity - без вращения
            GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

            // Доступ к RigidBody2D объекта
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            // Придаем о
            currentBulletVelocity.velocity = new Vector2(_fireSpeed, currentBulletVelocity.velocity.y);
        }
    }
}
