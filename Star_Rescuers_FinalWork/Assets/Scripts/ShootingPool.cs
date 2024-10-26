using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingPool : MonoBehaviour
{
    [SerializeField] private int poolCount = 10;

    [SerializeField] private bool autoExpand = false;

    // ��� ����� �������� �����
    [SerializeField] private ShotingPoolObject _bulletPrefab;


    // �������� ��������
    [SerializeField] private float _fireSpeed;

    //// �����, ������ ���� ��������
    //[SerializeField] private Transform _firePoint;

    //// ������� �� ��������
    //[SerializeField] private GameObject _fireFlash;

    private Rigidbody2D bullet;




    private PoolMono<ShotingPoolObject> pool;   

    private void Start()
    {
        this.pool = new PoolMono<ShotingPoolObject>(this._bulletPrefab, this.poolCount, this.transform);

        this.pool.autoExpand = this.autoExpand;

        bullet = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.CreateBullet();
        }
    }

    private void CreateBullet()
    {
        var bullet = this.pool.GetFreeElement();

        Rigidbody2D currentBulletVelocity = bullet.GetComponent<Rigidbody2D>();

        // �������� �������� � ��� ����������� ���� ��������� ������
       currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x, currentBulletVelocity.velocity.y);
    }
}
