using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float _speedPlayer = 0.5f;

    [SerializeField] private float _jumpForce; 
    
    [SerializeField] private float _flyForce;

    [SerializeField] private GameObject _flameToFly;

    private Animator animatorPlayer;

    private Rigidbody2D rb;

    private Vector2 moveVector;

    private bool isGround, isFly;

    private void Awake()
    {       
        rb = GetComponent<Rigidbody2D>();

        animatorPlayer = GetComponent<Animator>();       

        isGround = false;
    }
       
    void Update()
    {
        Walk();           
    }

    /// <summary>
    /// ������������
    /// </summary>
    private void Walk() 
    {        
        moveVector.x = Input.GetAxis("Horizontal");

        // ������ ������ ������������
        rb.velocity = new Vector2(moveVector.x * _speedPlayer, rb.velocity.y);

        // ������ ������ ������������
        //rb.AddForce(moveVector * speedPlayer);

        // ������� ������� � ����������� �� �������
        if (moveVector.x > 0)
        {
            LeftOrRigth(1);           
        }
        else if (moveVector.x < 0)
        {
            LeftOrRigth(-1);            
        }

        // ������� �������
        void LeftOrRigth(int leftOrRigth)
        {
            transform.localScale = new Vector2(leftOrRigth, 1);
        }

        // �������� ����
        if (Input.GetAxis("Horizontal") != 0 && isGround)
        {
            animatorPlayer.SetBool("isRun", true);
        }
        else
        {
            animatorPlayer.SetBool("isRun", false);
        }          
    }

    /// <summary>
    /// ���������, ��� ����� ��������� �� �����
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;            
        }
    }

    /// <summary>
    /// ���������, ��� ����� ��������� �� �� �����
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
