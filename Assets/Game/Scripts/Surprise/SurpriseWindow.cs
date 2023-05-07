using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SurpriseWindow : MonoBehaviour
{
    [SerializeField] private CanvasGroup _windowCg;
    [Header("Buttons")]
    [SerializeField] private Button _closeWindowBtn;

    private void Awake()
    {
        ShowSurpriseWindow(false);

        _closeWindowBtn.onClick.AddListener(() => { ShowSurpriseWindow(false); });
    }

    public void ShowSurpriseWindow(bool show)
    {
        _windowCg.alpha = show ? 1 : 0;
        _windowCg.blocksRaycasts = show;
        _windowCg.interactable = show;
    }
}
