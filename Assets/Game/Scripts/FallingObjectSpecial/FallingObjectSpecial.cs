using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpecial : MonoBehaviour
{
    public static Action OnSpecialItemCollect;

    [SerializeField] private float _speed = 5f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.velocity = Vector2.down * _speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Special item collected!");
            OnSpecialItemCollect?.Invoke();
        }
    }
}
