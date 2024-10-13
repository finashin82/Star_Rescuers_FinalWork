using UnityEngine;

public class ShooterPlayer : MonoBehaviour
{
    // Чем будет стрелять игрок
    [SerializeField] private GameObject _bulletPrefab;

    // Скорость стрельбы
    [SerializeField] private float _fireSpeed;

    // Точка, откуда идет стрельба
    [SerializeField] private Transform _firePoint;

    // Вспышка от выстрела
    [SerializeField] private GameObject _fireFlash;

    private void Update()
    {
        float horizontalDirection = Input.GetAxis("Horizontal");

        Shoot(horizontalDirection);

        Invoke("StopFireFlash", 0.5f);
    }

    public void Shoot(float direction)
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartFireFlash();

            // Создаем объект, которым будем стрелять. Quaternion.identity - без вращения
            GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

            // Доступ к RigidBody2D объекта
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            // Стрельба префабом в том направлении куда направлен объект
            currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x, currentBulletVelocity.velocity.y);           
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
}
