using UnityEngine;

public class ShooterPlayer : MonoBehaviour
{
    // ��� ����� �������� �����
    [SerializeField] private GameObject _bulletPrefab;

    // �������� ��������
    [SerializeField] private float _fireSpeed;

    // �����, ������ ���� ��������
    [SerializeField] private Transform _firePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            // ������� ������, ������� ����� ��������. Quaternion.identity - ��� ��������
            GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

            // ������ � RigidBody2D �������
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            // ������� �
            currentBulletVelocity.velocity = new Vector2(_fireSpeed, currentBulletVelocity.velocity.y);
        }
    }
}
