using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpecialItemController : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private SpawnSpecialItem _spawnSpecialItem;
    [SerializeField] private GeneralGameController _gameController;
    [Tooltip("adjust the value to control the probability of spawning a special item. For example, if you want a 50% chance of spawning a special item every 10 points, you could set it to 0.5f.")]
    [SerializeField, Range(0f, 1f)] private float _percentageOfProbabiltyOfSpawningItem;

    private void Awake()
    {
        ScoreController.OnScoreUp += EnableSpawner;
    }

    /// <summary>
    /// If score is divisable by 10
    /// _percentageOfProbabiltyOfSpawningItem =>
    ///     for example, if you want a 50% chance of spawning a special item every 10 points, you could set it to 0.5f.
    /// </summary>
    private void EnableSpawner()
    {
        if (_scoreController.Score % 10 == 0 && Random.value < _percentageOfProbabiltyOfSpawningItem)
        {
            _spawnSpecialItem.gameObject.SetActive(true);
            _spawnSpecialItem.gameObject.SetActive(false);

            _gameController.PauseGame();
        }
    }
}
