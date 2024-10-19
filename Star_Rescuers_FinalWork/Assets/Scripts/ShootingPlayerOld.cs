using UnityEngine;

public class ShootingPlayerOld : MonoBehaviour
{
    private Shooting shot;

    // ��� ����� �������� �����
    [SerializeField] private GameObject _bulletPrefab;

    // �������� ��������
    [SerializeField] private float _fireSpeed;

    // �����, ������ ���� ��������
    [SerializeField] private Transform _firePoint;

    // ������� �� ��������
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
