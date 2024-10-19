using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    /// <summary>
    /// Прыжок
    /// </summary>
    public void Jump(Rigidbody2D rb, float jumpForce)
    {      
        rb.AddForce(Vector2.up * jumpForce);
    }
}
