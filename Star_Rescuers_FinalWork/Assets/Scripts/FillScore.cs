using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillScore : MonoBehaviour
{
    [SerializeField] private Text _fillScore;

    [SerializeField] private int _countForEnemy;

    [SerializeField] private SoundInTheGame _soundInTheGame;

    private int scorePlayer;

    private void Awake()
    {        
        scorePlayer = 0;

        _fillScore.text = scorePlayer.ToString();
    }

    private void Start()
    {
        EventController.onScore?.Invoke(scorePlayer);
    }

    public void FillScorePlayer(Health health)
    {
        if (!health.IsAlive)
        {
            _soundInTheGame.SoundTakeBonus();

            scorePlayer += _countForEnemy;

            _fillScore.text = scorePlayer.ToString();

            EventController.onScore?.Invoke(scorePlayer);
        }        
    }
}
