using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [Tooltip("Номер уровня")]
    [SerializeField] private int _level;

    /// <summary>
    ///  Загружаем уровень
    /// </summary>
    public void LevelTransitionsButton()
    {
        Time.timeScale = 1;
        // Загружаем сцену
        SceneManager.LoadScene(_level);
    }

    /// <summary>
    ///  Переход на следующий уровень
    /// </summary>
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    ///  Повтор уровня
    /// </summary>
    public void RepeatLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Возврат в главное меню
    /// </summary>
    public void MainMenuLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Кнопка выхода из игры
    /// </summary>
    public void ExitButton()
    {
        Application.Quit();
    }
}
