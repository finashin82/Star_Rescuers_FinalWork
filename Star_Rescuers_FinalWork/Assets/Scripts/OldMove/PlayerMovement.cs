using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������ ��������� RigidBody2D ������������ ��� �������
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement vars")]

    // ���� ������
    [SerializeField] private float jumpForce;

    //���������� ��� �������� ������� �����
    [SerializeField] private bool isGrounded = false;

    // �������� ��������
    [SerializeField] private float speed;

    [Header("Settings")]

    // ���������� ������ �����, ��� �������� ������������ � ������
    [SerializeField] private Transform _groundColliderTransform;

    // ������, �� ������� ����� ����������� ��������
    [SerializeField] private AnimationCurve curve;

    // ������ ����������, ������� ��������� ������������ � ������
    [SerializeField] private float jumpOffset;

    // ���� �����, ����, � ������� ������������ ����
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Animator animatorPlayer;

    // ������� ������� �� ��������
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
        // ���������� ������ �����, ������� ��������� ������������ � ������
        Vector2 overlapCirclePosition = _groundColliderTransform.position;

        // ���������� true, ���� ���� ����� ���������� ������ ���� groundMask � false, ���� �� ����� ����������
        isGrounded = Physics2D.OverlapCircle(overlapCirclePosition, jumpOffset, groundMask);
    }

    /// <summary>
    /// �������� � ������ � ����
    /// </summary>
    /// <param name="direction"></param>
    /// <param name="isJumpButtonPressed"></param>
    public void Move(float direction, bool isJumpButtonPressed)
    {
        if (isJumpButtonPressed)
        {            
            Jump();
        }

        // float �� ���� �� ������, ������� ������ ������� != 0, � ���� ������ �����
        if (direction > 0.01f)
        {
            HorizontalMovement(direction);
        }

        if (direction < 0.01f)
        {
            HorizontalMovement(-direction);
        }

        // ������� ��� ������� �������� ����
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
    /// ������
    /// </summary>
    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    /// <summary>
    /// �������������� �������� (direction - �����������)
    /// </summary>
    /// <param name="direction"></param>
    private void HorizontalMovement( float direction)
    {
        // direction ���������� �� ������
        rb.velocity = new Vector2(curve.Evaluate(direction) * speed, rb.velocity.y);
    }

    /// <summary>
    /// ������� ������� �� ��������
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
    /// �������� �������� ��� ����
    /// </summary>
    /// <param name="isRunning"></param>
    private void AnimatorRunningPlayer (bool isRunning)
    {
        animatorPlayer.SetBool("isRunning", isRunning);
    }
}
