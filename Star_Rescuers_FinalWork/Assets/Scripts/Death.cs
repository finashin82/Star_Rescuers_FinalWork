using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animatorGamer;

    private Rigidbody2D rb;

    private GameObject gb;

    //private Collider2D collider;

    private void Awake()
    {
        animatorGamer = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        //collider = GetComponent<Collider2D>();

        gb = GetComponent<GameObject>();
    }

    /// <summary>
    /// Анимация смерти и смерть игрока
    /// </summary>
    /// <param name="health"></param>
    public void DeathPlayer(Health health)
    {
        // Если текущая жизнь меньше или равна 0, то запуск анимации и скрытие объекта
        if (!health.IsAlive)
        {
            rb.isKinematic = true;

            //gb.GetComponent<Collider2D>().enabled = false;

            //collider.enabled = false;       
            
            //CompositeCollider2D.Destroy(collider);

            //collider.GetComponent<Collider>().enabled = false;

            animatorGamer.SetBool("isDeath", true);            

            Invoke("DestroyObject", 1f);
        }
    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
