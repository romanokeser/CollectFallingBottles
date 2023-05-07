using UnityEngine;

public class FallingObjectScript : MonoBehaviour
{
    [SerializeField] private float _minSpeed = 1f;
    [SerializeField] private float _maxSpeed = 8f;


    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        float randomSpeed = Random.Range(_minSpeed, _maxSpeed);
        rb.velocity = Vector2.down * randomSpeed;
    }
}
