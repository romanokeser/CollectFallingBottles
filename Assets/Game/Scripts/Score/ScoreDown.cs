using System;
using UnityEngine;

public class ScoreDown : MonoBehaviour
{
    public static Action OnCollectableItemMissed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("CollectableItem"))
        {
            Debug.Log("Missed!");
            OnCollectableItemMissed?.Invoke();
        }
    }
}
