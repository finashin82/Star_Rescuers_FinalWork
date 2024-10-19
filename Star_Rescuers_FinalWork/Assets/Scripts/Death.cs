using System.Collections;
using UnityEngine;

public class Death : MonoBehaviour
{
    private Animator animatorGamer;

    private void Awake()
    {
        animatorGamer = GetComponent<Animator>();
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
            animatorGamer.SetBool("isDeath", true);            

            Invoke("DestroyObject", 1f);
        }
    }

    private void DestroyObject()
    {
        gameObject.SetActive(false);
    }
}
