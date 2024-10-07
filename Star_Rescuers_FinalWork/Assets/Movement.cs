using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speedPlayer = 0.5f;

    private Rigidbody2D rb;

    private Vector2 moveVector;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
       
    void Update()
    {
        Walk();
    }

    private void Walk() 
    {        
        moveVector.x = Input.GetAxis("Horizontal");

        // Первый способ передвижения
        rb.velocity = new Vector2(moveVector.x * speedPlayer, rb.velocity.y);

        // Второй способ передвижения
        //rb.AddForce(moveVector * speedPlayer);
    }
}
