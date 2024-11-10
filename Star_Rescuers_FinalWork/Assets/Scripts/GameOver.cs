using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    [SerializeField] private Text _scoreCount;

    [SerializeField] private GameObject _player;

    private void OnEnable()
    {
        EventController.onScore += ScoreCountGameOver;
    }

    private void OnDisable()
    {
        EventController.onScore -= ScoreCountGameOver;
    }

    public void GameOverPanel(Health health)
    {
        if (!health.IsAlive)
        {
            _gameOverPanel.SetActive(true);            
        }           
    }

    public void ScoreCountGameOver(int score) 
    {
        _scoreCount.text = "Score: " + score.ToString();
    }
}
