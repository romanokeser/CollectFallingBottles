using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHelper : MonoBehaviour
{
    public static Action OnEnemyCollect;
    public static Action OnRegularItemCollect;
    public static Action OnSpecialItemCollect;

    private void OnTriggerEnter2D(Collider2D fallingItem)
    {
        if (fallingItem.CompareTag("CollectableItem"))
        {
            Debug.Log("<color=yellow> COLLECT: </color> Collectable item!");
            fallingItem.gameObject.SetActive(false);
            OnRegularItemCollect?.Invoke();
        }

        if (fallingItem.CompareTag("Enemy"))
        {
            Debug.Log("<color=yellow> COLLECT: </color> <color=red>Enemy item! </color>");
            fallingItem.gameObject.SetActive(false);
            OnEnemyCollect?.Invoke();
        }

        if (fallingItem.CompareTag("SpecialItem"))
        {
            Debug.Log("<color=yellow> COLLECT: </color> <color=pink> Special item! </color>");
            fallingItem.gameObject.SetActive(false);
            OnSpecialItemCollect?.Invoke();
        }
    }
}
