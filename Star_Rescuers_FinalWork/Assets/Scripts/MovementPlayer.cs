using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementPlayer : MonoBehaviour
{
    private TimeToFly timeToFly;

    [SerializeField] private float _speedPlayer = 0.5f;

    [SerializeField] private float _jumpForce; 
    
    [SerializeField] private float _flyForce;

    [SerializeField] private GameObject _flameToFly;

    [SerializeField] private float maxTimeToFly;

    //private float currentTimeToFly;

    //public float CurrentTimeToFly { get { return currentTimeToFly; } set { currentTimeToFly = value; } }

    private Animator animatorPlayer;

    private Rigidbody2D rb;

    private Vector2 moveVector;

    private bool isGround, isFly;

    private void Awake()
    {
        //jumpPlayer = GetComponent<JumpPlayer>();

        rb = GetComponent<Rigidbody2D>();

        animatorPlayer = GetComponent<Animator>();       

        isGround = false;

        //currentTimeToFly = maxTimeToFly;
    }
       
    void Update()
    {
        Walk();

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animatorPlayer.SetBool("isJump", true);
            
            Jump();
        }
        else
        {
            animatorPlayer.SetBool("isJump", false);
        }

        // Когда отпускаем пробел после прыжка, можно летать
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isFly = true;
        }
        
        Fly();        
    }

    /// <summary>
    /// Передвижение
    /// </summary>
    private void Walk() 
    {        
        moveVector.x = Input.GetAxis("Horizontal");

        // Первый способ передвижения
        rb.velocity = new Vector2(moveVector.x * _speedPlayer, rb.velocity.y);

        // Второй способ передвижения
        //rb.AddForce(moveVector * speedPlayer);

        // Поворот спрайта в зависимости от условий
        if (moveVector.x > 0)
        {
            LeftOrRigth(1);           
        }
        else if (moveVector.x < 0)
        {
            LeftOrRigth(-1);            
        }

        // Поворот спрайта
        void LeftOrRigth(int leftOrRigth)
        {
            transform.localScale = new Vector2(leftOrRigth, 1);
        }

        // Анимация бега
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
    /// Прыжок
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animatorPlayer.SetBool("isJump", true);

            rb.AddForce(Vector2.up * _jumpForce);
        }
        else
        {
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
        if (Input.GetKey(KeyCode.Space) && isFly)
        {      
            if (timeToFly.CurrentTimeToFly > 0)
            {
                timeToFly.CurrentTimeToFly -= Time.deltaTime;

                _flameToFly.SetActive(true);

                animatorPlayer.SetBool("isJump", true);

                rb.AddForce(Vector2.up * _flyForce, ForceMode2D.Force);
            }

            Debug.Log($"Time To Fly: {timeToFly.CurrentTimeToFly}");
        }
        else
        {
            _flameToFly.SetActive(false);

            animatorPlayer.SetBool("isJump", false);
        }        
    }    

    /// <summary>
    /// Проверяем, что игрок находится на земле
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGround = true;
            isFly = false;
        }
    }

    /// <summary>
    /// Проверяем, что игрок находится не на земле
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
