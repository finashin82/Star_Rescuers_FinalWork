using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private JumpPlayer jumpPlayer;

    [SerializeField] private float _speedPlayer = 0.5f;

    [SerializeField] private float _jumpForce;

    [SerializeField] private float _flyForce;

    [SerializeField] private GameObject _flameToFly;

    //private Animator animatorPlayer;

    public Animator AnimatorPlayer { get; set; }

    private Rigidbody2D rb;

    private Vector2 moveVector;

    private bool isGround, isFly;

    private StateMachine stateMachine;

    private void Awake()
    {
        stateMachine = new StateMachine();

        stateMachine.Initialize(new IdleState(this));


        jumpPlayer = GetComponent<JumpPlayer>();

        rb = GetComponent<Rigidbody2D>();

        AnimatorPlayer = GetComponent<Animator>();

        isGround = false;
    }

    private void Update()
    {
        stateMachine.CurrentState.Update();

        //if (Input.GetKeyDown(KeyCode.R))
        //{
        //    stateMachine.ChangeState(new WalkState(this));
        //}

        moveVector.x = Input.GetAxis("Horizontal");

        if (moveVector.x != 0)
        {
            stateMachine.ChangeState(new WalkState(this));
        }
        else
        {
            stateMachine.ChangeState(new IdleState(this));
        }
    }
}
