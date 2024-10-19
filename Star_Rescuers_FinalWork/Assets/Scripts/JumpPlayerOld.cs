using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayerOld : MonoBehaviour
{
    [SerializeField] private float jumpForce;

    private Rigidbody2D rb;

    private Animator animatorPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animatorPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animatorPlayer.SetBool("isJump", true);

            rb.AddForce(Vector2.up * jumpForce);
        }
        else
        {
            animatorPlayer.SetBool("isJump", false);
        }        
    }
}
