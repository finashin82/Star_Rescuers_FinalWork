using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    private SoundInTheGame soundInTheGame;

    [SerializeField] private float _jumpForce;

    private Animator animatorPlayer;

    private Rigidbody2D rb;

    private bool isGround;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        animatorPlayer = GetComponent<Animator>();

        soundInTheGame = GetComponent<SoundInTheGame>();

        isGround = false;
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            soundInTheGame.SoundJumpPlayer();

            animatorPlayer.SetBool("isJump", true);

            Jump();
        }
        else
        {
            animatorPlayer.SetBool("isJump", false);
        }
    }

    /// <summary>
    /// ������
    /// </summary>
    public void Jump()
    {      
        rb.AddForce(Vector2.up * _jumpForce);
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
