using UnityEngine;

public class ShootingPlayerOld : MonoBehaviour
{
    private Shooting shot;

    // Чем будет стрелять игрок
    [SerializeField] private GameObject _bulletPrefab;

    // Скорость стрельбы
    [SerializeField] private float _fireSpeed;

    // Точка, откуда идет стрельба
    [SerializeField] private Transform _firePoint;

    // Вспышка от выстрела
    [SerializeField] private GameObject _fireFlash;

    private void Awake()
    {
        shot = GetComponent<Shooting>();
    }

    private void Update()
    {    
        if (Input.GetMouseButtonDown(0))
        {
            StartFireFlash();

            //shot.Shot(_bulletPrefab, _firePoint, _fireSpeed);
        }

        Invoke("StopFireFlash", 0.2f);
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
