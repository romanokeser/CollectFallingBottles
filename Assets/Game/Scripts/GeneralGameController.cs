using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GeneralGameController : MonoBehaviour
{
    [SerializeField] private HealthController _healthController;
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private CanvasGroup _gameOverCanvas;
    [Header("Buttons")]
    [SerializeField] private Button _playAgainBtn;
    [SerializeField] private Button _closeBtn;


    private void Awake()
    {
        HealthController.OnAllHealthWasted += GameOver;

        ShowGameOverUI(false);
        _playAgainBtn.onClick.AddListener(PlayAgain);
        _closeBtn.onClick.AddListener(CloseApp);
    }


    public void GameOver()
    {
        PauseGame(true);
        ShowGameOverUI(true);
        SaveScore();
        ResetScore();
    }

    private void PauseGame(bool pause)
    {
        _enemySpawner.enabled = !pause;
        DestroyAllEnemies();
    }

    private void ShowGameOverUI(bool show)
    {
        _gameOverCanvas.DOFade(show ? 1 : 0, 0.25f);
        _gameOverCanvas.blocksRaycasts = show;
        _gameOverCanvas.interactable = show;
    }

    private void ResetScore()
    {
        _healthController.Health = _healthController.InitHealth;
        _scoreController.ResetScore();
    }

    private void SaveScore()
    {
        //if new score is new record then save it, if not just reset it
    }

    private void CloseApp()
    {
       Application.Quit();
    }

    private void PlayAgain()
    {
        ShowGameOverUI(false);
        PauseGame(false);
        _healthController.HealthTextures.ForEach(go => go.gameObject.SetActive(true));
    }
    private void DestroyAllEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
    }
}
