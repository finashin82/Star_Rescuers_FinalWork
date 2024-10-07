using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Делаем компонент RigidBody2D обязательным для скрипта
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]

    // Сила прыжка
    [SerializeField] private float jumpForce;

    //Переменная для проверки касания земли
    [SerializeField] private bool isGrounded = false;

    // Скорость движения
    [SerializeField] private float speed;

    [Header("Settings")]

    // Координаты центра круга, для проверки столкновения с землей
    [SerializeField] private Transform _groundColliderTransform;

    // Кривая, по которой будет развиваться скорость
    [SerializeField] private AnimationCurve curve;

    // Радиус окружности, которая проверяет столкновение с землей
    [SerializeField] private float jumpOffset;

    // Слой земли, слой, с которым сталкивается круг
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Animator animatorPlayer;

    // Поворот спрайта по движению
    private Transform flipSprite;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        flipSprite = GetComponent<Transform>();

        animatorPlayer = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Координаты центра круга, который проверяет столкновение с землей
        Vector2 overlapCirclePosition = _groundColliderTransform.position;

        // Возвращает true, если круг будет пересекать объект слоя groundMask и false, если не будет пересекать
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    /// <summary>
    /// Движение и прыжок в игре
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="isJumpButtonPressed"></param>
    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {            
            Jump();
        }

        // float до нуля не падает, поэтому нельзя ставить != 0, и берём модуль числа
        if (direction > 0.01f)
        {
            HorizontalMovement(direction);
        }

        if (direction < 0.01f)
        {
            HorizontalMovement(-direction);
        }

        // Условия для запуска анимации бега
        if (Mathf.Abs(direction) > 0.01f && isGrounded)
        {
           AnimatorRunningPlayer(true);            
        }
        else
        {
            AnimatorRunningPlayer(false);
        }        

        FlipPlayer(direction);
    }

    /// <summary>
    /// Прыжок
    /// </summary>
    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /// <summary>
    /// Горизонтальное движение (direction - направление)
    /// </summary>
    /// <param name="direction"></param>
    private void HorizontalMovement( float direction)
    {
        // direction изменяется по кривой
        rb.velocity = new Vector2(curve.Evaluate(direction) * speed, rb.velocity.y);
    }

    /// <summary>
    /// Поворот спрайта по движению
    /// </summary>
    /// <param name="direction"></param>
    private void FlipPlayer(float direction)
    {
        if (direction > 0)
        {
            Vector2 rotate = transform.eulerAngles;
            rotate.y = 0;
            flipSprite.rotation = Quaternion.Euler(rotate);
        }
        else if (direction < 0)
        {
            Vector2 rotate = transform.eulerAngles;
            rotate.y = -180;
            flipSprite.rotation = Quaternion.Euler(rotate);
        }
    }

    /// <summary>
    /// Анимация движения при беге
    /// </summary>
    /// <param name="isRunning"></param>
    private void AnimatorRunningPlayer (bool isRunning)
    {
        animatorPlayer.SetBool("isRunning", isRunning);
    }
}
