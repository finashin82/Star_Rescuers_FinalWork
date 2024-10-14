using UnityEngine;

public class ShooterPlayer : MonoBehaviour
{
    // ��� ����� �������� �����
    [SerializeField] private GameObject _bulletPrefab;

    // �������� ��������
    [SerializeField] private float _fireSpeed;

    // �����, ������ ���� ��������
    [SerializeField] private Transform _firePoint;

    // ������� �� ��������
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

            // ������� ������, ������� ����� ��������. Quaternion.identity - ��� ��������
            GameObject currentBullet = Instantiate(_bulletPrefab, _firePoint.position, Quaternion.identity);

            // ������ � RigidBody2D �������
            Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

            // �������� �������� � ��� ����������� ���� ��������� ������
            currentBulletVelocity.velocity = new Vector2(_fireSpeed * transform.localScale.x, currentBulletVelocity.velocity.y);           
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
}
