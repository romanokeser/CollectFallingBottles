using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public int Score;

    private void Awake()
    {
        EnemyCollisionDetection.OnEnemyCollect += ScoreUp;
    }

    

    private void ScoreUp()
    {
        Score++;
        _scoreText.SetText("Score: " + Score.ToString());
    }

    public void ResetScore()
    {
        Score = 0;
        _scoreText.SetText("Score: 0");

    }
}
