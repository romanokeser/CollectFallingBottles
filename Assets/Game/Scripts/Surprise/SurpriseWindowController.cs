using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurpriseWindowController : MonoBehaviour
{
    [SerializeField] private SurpriseWindow _surpriseWindow;

    private void Awake()
    {
        EventHelper.OnSpecialItemCollect += ShowSurpriseWindow;
    }

    private void ShowSurpriseWindow()
    {
        _surpriseWindow.ShowSurpriseWindow(true);
        GeneralGameController.Instance.PauseGame();
    }
}
