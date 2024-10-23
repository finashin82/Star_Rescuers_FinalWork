using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlayer : MonoBehaviour
{
    [SerializeField] private GameObject _flameToFly;

    [SerializeField] private float _flyForce;

    [SerializeField] private float maxTimeToFly;

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

        // Когда отпускаем пробел после прыжка, можно летать
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFly = true;
        }
    }

    /// <summary>
    /// Полёт
    /// </summary>
    private void Fly()
    {
        rb.AddForce(Vector2.up * _flyForce, ForceMode2D.Force);
    }

    /// <summary>
    /// Увеличение текущего времени полета
    /// </summary>
    /// <param name="time"></param>
    public void AddCurrentTimeToFly(float time)
    {
        currentTimeToFly += time;

        if (currentTimeToFly > maxTimeToFly)
        {
            currentTimeToFly = maxTimeToFly;
        }

        Debug.Log($"Current Time To Fly: {currentTimeToFly}");
    }

    /// <summary>
    /// Увеличение максимального времени полета
    /// </summary>
    public void AddMaxTimeToFly(float time)
    {
        maxTimeToFly += time;

        Debug.Log($"Max Time To Fly: {maxTimeToFly}");
    }

    /// <summary>
    /// Проверяем, что игрок находится на земле
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
