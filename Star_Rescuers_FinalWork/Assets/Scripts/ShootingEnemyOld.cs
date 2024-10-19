using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyOld : MonoBehaviour
{
    //private Shooting shot;

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

    // ����� ����� ���������
    private float timeShoot;

    // ���������� �� �������
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

    // ��� ����� � ������� ���������� ��������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFire = true;
        }
    }

    // ��� ������ �� �������� �������� ������������
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isFire = false;
        }
    }
}
