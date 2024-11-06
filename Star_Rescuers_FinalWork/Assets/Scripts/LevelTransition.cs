using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [Tooltip("����� ������")]
    [SerializeField] private int _level;

    /// <summary>
    ///  ��������� �������
    /// </summary>
    public void LevelTransitionsButton()
    {
        Time.timeScale = 1;
        // ��������� �����
        SceneManager.LoadScene(_level);
    }

    /// <summary>
    ///  ������� �� ��������� �������
    /// </summary>
    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    ///  ������ ������
    /// </summary>
    public void RepeatLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// ������� � ������� ����
    /// </summary>
    public void MainMenuLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// ������ ������ �� ����
    /// </summary>
    public void ExitButton()
    {
        Application.Quit();
    }
}
