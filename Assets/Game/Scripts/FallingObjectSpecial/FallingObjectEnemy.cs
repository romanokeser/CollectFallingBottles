using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectEnemy : MonoBehaviour
{
    public static Action OnEnemyHit;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Enemy hit!");
            OnEnemyHit?.Invoke();
        }
    }



}
