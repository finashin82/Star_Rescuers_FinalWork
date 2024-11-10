using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animatorGamer;

    private Rigidbody2D rb;

    private GameObject gb;

    private Shooting shooting;

    private BoxCollider2D collider2d;

    private void Awake()
    {
        animatorGamer = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();

        collider2d = GetComponent<BoxCollider2D>();

        gb = GetComponent<GameObject>();

        shooting = GetComponent<Shooting>();
    }

    /// <summary>
    /// �������� ������ � ������ ������
    /// </summary>
    /// <param name="health"></param>
    public void DeathPlayer(Health health)
    {
        // ���� ������� ����� ������ ��� ����� 0, �� ������ �������� � ������� �������
        if (!health.IsAlive)
        { 
            // ��������� ������ ��������
            shooting.enabled = false;

            // ������� RigidBody2D � ����� ����������
            rb.isKinematic = true;            

            // ��������� ���������
            collider2d.enabled = false;

            animatorGamer.SetBool("isDeath", true);            

            Invoke("DestroyObject", 1f);
        }
    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
