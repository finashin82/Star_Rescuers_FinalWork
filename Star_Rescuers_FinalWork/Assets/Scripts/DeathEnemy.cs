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
    /// Анимация смерти и смерть игрока
    /// </summary>
    /// <param name="health"></param>
    public void DeathPlayer(Health health)
    {
        // Если текущая жизнь меньше или равна 0, то запуск анимации и скрытие объекта
        if (!health.IsAlive)
        {
            //animatorGamer.SetBool("isDeath", true);

            Coroutine coroutin = StartCoroutine(timer());
        }
    }

    // Исчезновение объекта после смерти
    private IEnumerator timer()
    {
        // Вызывает действие через 2 секунды
        yield return new WaitForSeconds(0.5f);

        gameObject.SetActive(false);
    }
}
