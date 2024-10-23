using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _flameToFly;

    [SerializeField] private float _flyForce;

    [SerializeField] private float maxTimeToFly;

    [SerializeField] private UnityEvent<FlyPlayer> flyEvent;

    public float MaxTimeToFly => maxTimeToFly;

    public float CurrentTimeToFly => currentTimeToFly;

    private Rigidbody2D rb;

    private Animator animatorPlayer;

    private float currentTimeToFly;

    private bool isFly;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        animatorPlayer = GetComponent<Animator>();

        currentTimeToFly = maxTimeToFly;
    }
   
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isFly)
        {
            if (currentTimeToFly > 0)
            {
                currentTimeToFly -= Time.deltaTime;

                flyEvent?.Invoke(this);

                _flameToFly.SetActive(true);

                animatorPlayer.SetBool("isJump", true);

                Fly();
            }
        }
        else
        {
            _flameToFly.SetActive(false);

            animatorPlayer.SetBool("isJump", false);
        }

        // ����� ��������� ������ ����� ������, ����� ������
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFly = true;
        }
    }

    /// <summary>
    /// ����
    /// </summary>
    private void Fly()
    {
        rb.AddForce(Vector2.up * _flyForce, ForceMode2D.Force);
    }

    /// <summary>
    /// ���������� �������� ������� ������
    /// </summary>
    /// <param name="time"></param>
    public void AddCurrentTimeToFly(float time)
    {
        currentTimeToFly += time;

        if (currentTimeToFly > maxTimeToFly)
        {
            currentTimeToFly = maxTimeToFly;
        }
    }

    /// <summary>
    /// ���������� ������������� ������� ������
    /// </summary>
    public void AddMaxTimeToFly(float time)
    {
        maxTimeToFly += time;
    }

    /// <summary>
    /// ���������, ��� ����� ��������� �� �����
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {           
            isFly = false;
        }
    }   
}
