using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    // ��� ����� �������� �����
    [SerializeField] private GameObject _bullet;

    // �������� ��������
    [SerializeField] private float fireSpeed;

    // �����, ������ ���� ��������
    [SerializeField] private Transform firePoint;

    /// <summary>
    /// ��������, direction - �����������
    /// </summary>
    /// <param name="direction"></param>
    public void Shoot(float direction)
    {
        // ������� ������, ������� ����� ��������. Quaternion.identity - ��� ��������
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
