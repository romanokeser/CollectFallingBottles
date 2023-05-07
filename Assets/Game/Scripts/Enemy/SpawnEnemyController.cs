using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyController : MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private SpawnEnemy _spawnEnemy;

    [SerializeField, Range(0f, 1f)] private float _percentageOfProbabiltyOfSpawningItem;


    private void Awake()
    {
        ScoreController.OnScoreUp += EnableEnemySpawner;
    }

    private void EnableEnemySpawner()
    {
        if (_scoreController.Score % 10 == 0 && UnityEngine.Random.value < _percentageOfProbabiltyOfSpawningItem)
        {
            _spawnEnemy.gameObject.SetActive(true);
            _spawnEnemy.gameObject.SetActive(false);
        }
    }
}
