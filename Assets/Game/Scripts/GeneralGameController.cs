using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Active,
    Paused,
    GameOver
}

public class GeneralGameController : MonoBehaviour
{
    public static GeneralGameController Instance;

    [SerializeField] private HealthController _healthController;
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private FallingObjectSpawner _enemySpawner;
    [SerializeField] private SpawnSpecialItem _enemySpawnerSpecial;
    [SerializeField] private PlayerDrag _playerDrag;
    [SerializeField] private CanvasGroup _gameOverCanvas;
    [Header("Buttons")]
    [SerializeField] private Button _playAgainBtn;
    [SerializeField] private Button _closeBtn;

    public static GameState GameStateGlobal;


    private void Awake()
    {
        if(Instance == null)
            Instance = this;

        HealthController.OnAllHealthWasted += GameOver;

        ShowGameOverUI(false);
        _playAgainBtn.onClick.AddListener(PlayAgain);
        _closeBtn.onClick.AddListener(CloseApp);

        GameStateGlobal = GameState.Active;
    }

    private void SetGameState(GameState newState)
    {
        GameStateGlobal = newState;
    }

    public void GameOver()
    {
        PauseGame();
        ShowGameOverUI(true);
        SaveScore();
        ResetScore();
        SetGameState(GameState.Paused);
    }

    public void PauseGame()
    {
        _enemySpawner.enabled = false;
        _enemySpawnerSpecial.enabled = false;
        DestroyAllEnemies();
        SetGameState(GameState.Paused);
    }

    public void ResumeGame()
    {
        _enemySpawner.enabled = true;
        _enemySpawnerSpecial.enabled = true;
        SetGameState(GameState.Active);
        _playerDrag.SetPlayerToCenter();
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
        ResumeGame();
        ShowHealthTextures(true);
        _scoreController.ResetScore();
        SetGameState(GameState.Active);
    }

    private void ShowHealthTextures(bool show)
    {
        _healthController.HealthTextures.ForEach(go => go.gameObject.SetActive(show));
    }

    private void DestroyAllEnemies()
    {
        GameObject[] collectableItem = GameObject.FindGameObjectsWithTag("CollectableItem");
        GameObject[] specialItems = GameObject.FindGameObjectsWithTag("SpecialItem");

        foreach (GameObject enemy in collectableItem)
        {
            Destroy(enemy);
        }

        foreach (GameObject specail in specialItems)
        {
            Destroy(specail);
        }
    }
}
