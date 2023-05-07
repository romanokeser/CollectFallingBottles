using System;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public static Action OnAllHealthWasted;
    public List<GameObject> HealthTextures;
    public int Health;
    public int InitHealth = 3;

    private void Awake()
    {
        Health = 3;
        ScoreDown.OnCollectableItemMissed += HealthDown;
    }

    private void HealthDown()
    {
        int temp = Health - 1;
        if (temp == 0)
        {
            Debug.Log("Game over!");
            HealthTextures.ForEach(go => go.gameObject.SetActive(false));

            OnAllHealthWasted?.Invoke();
        }
        else
        {
            Health -= 1;
            HealthTextures[Health].SetActive(false);

        }
    }
}
