using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
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
}
