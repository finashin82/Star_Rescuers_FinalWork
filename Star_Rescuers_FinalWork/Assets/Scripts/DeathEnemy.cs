using System.Collections;
using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    private Animator animatorGamer;

    private void Awake()
    {
        animatorGamer = GetComponent<Animator>();
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
            //animatorGamer.SetBool("isDeath", true);

            Coroutine coroutin = StartCoroutine(timer());
        }
    }

    // ������������ ������� ����� ������
    private IEnumerator timer()
    {
        // �������� �������� ����� 2 �������
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
