using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPanel;

    public void GameOverPanel(Health health)
    {
        if (!health.IsAlive)
            _gameOverPanel.SetActive(true);
    }
}
