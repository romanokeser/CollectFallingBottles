using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DebuggingGeneral : MonoBehaviour
{
    [SerializeField] private Slider _speed;
    [SerializeField] private FallingObjectSpawner _fallingObjectSpawner;
    [SerializeField] private Button _openDebugBtn;
    [SerializeField] private Button _closeDebugBtn;
    [SerializeField] private CanvasGroup _debugWindowCG;

    private void Start()
    {
        _openDebugBtn.onClick.AddListener(() => { OpenDebugWindow(true); });
        _closeDebugBtn.onClick.AddListener(() => { OpenDebugWindow(false); });

        OpenDebugWindow(false);
    }

    private void OpenDebugWindow(bool open)
    {
        if (open)
        {
            ShowWindow(true);
            GeneralGameController.Instance.PauseGame();

        }
        else
        {
            ShowWindow(false);
            SaveOptions();
            GeneralGameController.Instance.ResumeGame();
        }
    }

    private void ShowWindow(bool show)
    {
        _debugWindowCG.alpha = show ? 1 : 0;
        _debugWindowCG.interactable = show;
        _debugWindowCG.blocksRaycasts = show;
    }

    private void SaveOptions()
    {
        _fallingObjectSpawner.FrequencySpawning = _speed.value;
    }
}
