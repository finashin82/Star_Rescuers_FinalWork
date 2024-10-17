using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : MonoBehaviour
{
    // ��� ����� �������� �����
    [SerializeField] private GameObject _bulletPrefab;

    // �������� ��������
    [SerializeField] private float _fireSpeed;

    // �����, ������ ���� ��������
    [SerializeField] private Transform _firePoint;

    // ������� �� ��������
    [SerializeField] private GameObject _fireFlash;

    // ����� ����� ���������
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
    /// �������
    /// </summary>
    public void Shoot()
    {        
        StartFireFlash();

        // ������� ������, ������� ����� ��������. Quaternion.identity - ��� ��������
        GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

        // ������ � RigidBody2D �������
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        // �������� �������� � ��� ����������� ���� ��������� ������
        currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x, currentBulletVelocity.velocity.y);       
    }      

    /// <summary>
    /// ������ ������� ��������
    /// </summary>
    private void StopFireFlash()
    {
        _fireFlash.SetActive(false);
    }

    /// <summary>
    /// �������� ������� ��������
    /// </summary>
    private void StartFireFlash()
    {
        _fireFlash.SetActive(true);
    }

    /// <summary>
    /// ������� Enemy � ������� ������
    /// </summary>
    private void DirectionOfThePlayer()
    {
        Vector3 playerPos = player.position;
        Vector3 enemyPos = transform.position;

        if (playerPos.x < enemyPos.x) // ����� ��������� ����� �� �����
        {
            transform.localScale = new Vector2(-1, 1); // ������������ ����� �����
        }
        else // ����� ��������� ������ �� �����
        {
            transform.localScale = new Vector2(1, 1); // ������������ ����� ������
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
