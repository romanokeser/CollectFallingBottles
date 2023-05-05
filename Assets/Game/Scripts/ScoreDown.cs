using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDown : MonoBehaviour
{
    public static Action OnEnemyNotCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Missed!");
            OnEnemyNotCollected?.Invoke();
        }
    }
}
