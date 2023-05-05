using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static Action OnAllHealthWasted;
    [SerializeField] private List<GameObject> _healthTextures;
    public int Health;
    public int InitHealth = 3;

    private void Awake()
    {
        Health = 3;
        ScoreDown.OnEnemyNotCollected += HealthDown;
    }

    private void HealthDown()
    {
        if (Health == 0)
        {
            Debug.Log("Game over!");
            OnAllHealthWasted?.Invoke();
        }
        else
        {
            Health -= 1;
            _healthTextures[Health].SetActive(false);

        }
    }
}
