using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotingPoolObject : MonoBehaviour
{
    // ��� ����� �������� �����
    //[SerializeField] private GameObject _bulletPrefab;

    //// �������� ��������
    //[SerializeField] private float _fireSpeed;

    // �����, ������ ���� ��������
    [SerializeField] private Transform _firePoint;

    // ������� �� ��������
    [SerializeField] private GameObject _fireFlash;

    /// <summary>
    /// ��������
    /// </summary>
    /// <param name="bulletPrefab"></param>
    /// <param name="firePoint"></param>
    /// <param name="fireSpeed"></param>
    public void Shot()
    {
        // ������� ������, ������� ����� ��������. Quaternion.identity - ��� ��������
        //GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

        // ������ � RigidBody2D �������
        //Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        //// �������� �������� � ��� ����������� ���� ��������� ������
        //currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x, currentBulletVelocity.velocity.y);
    }    
}
