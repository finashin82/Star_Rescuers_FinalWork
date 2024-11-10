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
            Invoke("GameOverPanel", 2f);
        }
    }

    //public void GameOverPanel()
    //{
    //    if (!_player.activeInHierarchy)
    //    {
    //        _gameOverPanel.SetActive(true);
    //        Debug.Log("+");
    //    }           
    //}

    public void ScoreCountGameOver(int score) 
    {
        _scoreCount.text = "Score: " + score.ToString();
    }

    private void GameOverPanel() 
    {
        _gameOverPanel.SetActive(true);
    }
}
