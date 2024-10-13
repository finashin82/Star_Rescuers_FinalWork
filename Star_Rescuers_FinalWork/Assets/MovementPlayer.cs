using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 0.5f;

    [SerializeField] private float jumpForce;    

    private Animator _animatorPlayer;

    private Rigidbody2D rb;

    private Vector2 moveVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animatorPlayer = GetComponent<Animator>();
    }
       
    void Update()
    {
        Walk();
        Jump();
    }

    private void Walk() 
    {        
        moveVector.x = Input.GetAxis("Horizontal");

        // Первый способ передвижения
        rb.velocity = new Vector2(moveVector.x * speedPlayer, rb.velocity.y);

        // Второй способ передвижения
        //rb.AddForce(moveVector * speedPlayer);

        if (Input.GetAxis("Horizontal") != 0)
        {
            _animatorPlayer.SetBool("isRun", true);
        }
        else
        {
            _animatorPlayer.SetBool("isRun", false);
        }

        if (moveVector.x > 0)
        {
            transform.localScale = new Vector2(1, 1);
            //rb.transform.Rotate(0, 0, 0);
        }
        else if (moveVector.x < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            //rb.transform.Rotate(0, -180, 0);
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce);
        }
    }
}
