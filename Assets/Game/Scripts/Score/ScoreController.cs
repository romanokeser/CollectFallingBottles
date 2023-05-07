using System;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static Action OnScoreUp;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public int Score;

    private void Awake()
    {
        EventHelper.OnRegularItemCollect += ScoreUp;
    }

    private void ScoreUp()
    {
        Score++;
        _scoreText.SetText("Score: " + Score.ToString());

        OnScoreUp?.Invoke();
    }

    public void ResetScore()
    {
        Score = 0;
        _scoreText.SetText("Score: 0");
    }
}
