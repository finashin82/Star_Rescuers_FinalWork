using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : Shooting
{
    [SerializeField] private AudioSource _soundShooting;

    // ����� ����� ���������
    [SerializeField] private float _timeShoot;   

    // ����� ����� ���������
    private float timeShoot;

    // ���������� �� �������
    private bool isFire;

    private Transform player;

    private void Awake()
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
                StartFireFlash();

                _soundShooting.Play();

                Shot();
               
                Invoke("StopFireFlash", 0.2f);

                timeShoot = _timeShoot;
            }
        }
    }   

    /// <summary>
    /// ������� Enemy � ������� ������
    /// </summary>
    private void DirectionOfThePlayer()
    {
        Vector2 playerPos = player.position;
        Vector2 enemyPos = transform.position;

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
