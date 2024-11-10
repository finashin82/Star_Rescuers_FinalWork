using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class WinLevel : MonoBehaviour
{
    [SerializeField] private GameObject _winLevelPanel;

    [SerializeField] private Text _scoreCountWin;

    private void OnEnable()
    {
        EventController.onScore += ScoreCountGameWin;
    }

    private void OnDisable()
    {
        EventController.onScore -= ScoreCountGameWin;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _winLevelPanel.SetActive(true);
        }
    }

    public void ScoreCountGameWin(int score)
    {
        _scoreCountWin.text = "Score: " + score.ToString();
    }
}
