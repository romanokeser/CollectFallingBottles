using System;
using UnityEngine;

public class FallingObjectCollisionDetection : MonoBehaviour
{
    public static Action OnEnemyCollect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Collected regular item!");
            other.gameObject.SetActive(false);
            OnEnemyCollect?.Invoke();
        }
    }
}
