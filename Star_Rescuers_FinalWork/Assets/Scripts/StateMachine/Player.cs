using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Player : MonoBehaviour
{
    private JumpPlayer jumpPlayer;

    [SerializeField] private float _speedPlayer = 0.5f;

    public float SpeedPlayer => _speedPlayer;

    [SerializeField] private float _jumpForce;

    public float JumpForce => _jumpForce;

    [SerializeField] private float _flyForce;

    public float FlyForce => _flyForce;

    [SerializeField] private GameObject _flameToFly;

    private Animator animatorPlayer;

    //public Animator AnimatorPlayer { get; set; }

    public Rigidbody2D RB { get; set; }

    private Vector2 moveVector;

    public Vector2 MoveVector => moveVector;

    private bool isGround, isFly;

    public bool IsGround { get { return isGround;  } set { isGround = value;  } }

    private StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new StateMachine();

        stateMachine.Initialize(new IdleState(this));

        jumpPlayer = GetComponent<JumpPlayer>();

        RB = GetComponent<Rigidbody2D>();

        animatorPlayer = GetComponent<Animator>();

        isGround = false;        
    }

    private void Update()
    {
        stateMachine.CurrentState.Update();

        moveVector.x = Input.GetAxis("Horizontal");

        // Ходьба через состояние
        if (moveVector.x != 0)
        {
            animatorPlayer.SetBool("isRun", true);

            stateMachine.ChangeState(new WalkState(this));
        }
        else
        {
            animatorPlayer.SetBool("isRun", false);;
        }

        // Анимация ходьбы
        if (Input.GetAxis("Horizontal") != 0 && isGround)
        {            
            animatorPlayer.SetBool("isRun", true);
        }
        else
        {
            animatorPlayer.SetBool("isRun", false);
        }

        // Прыжок и его анимация
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animatorPlayer.SetBool("isJump", true);

            stateMachine.ChangeState(new JumpState(this));
        }
        else
        {
            animatorPlayer.SetBool("isJump", false);            
        }

        // Полет
        if (Input.GetKey(KeyCode.Space) && isFly)
        {
            _flameToFly.SetActive(true);

            animatorPlayer.SetBool("isJump", true);

           stateMachine.ChangeState(new FlyState(this));
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

            Debug.Log($"isFly: {isFly}");
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
            isFly = true;

            Debug.Log($"isFly: {isFly}");
        }
    }
}
