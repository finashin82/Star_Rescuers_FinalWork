using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopTime : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    [SerializeField] private GameObject _winPanel;

    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private GameObject _player;



    private void Update()
    {
        if (_pausePanel.activeInHierarchy || _winPanel.activeInHierarchy || _gameOverPanel.activeInHierarchy)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
