using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 8f;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 direction = Vector2.right;
    private GameManager gameManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
        rb.velocity = direction * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            direction.y = -direction.y;
        }

        if (collision.gameObject.CompareTag("Paddle"))
        {
            direction.x = -direction.x;
            moveSpeed += 0.5f;
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            HandleGoal(collision.gameObject);
        }

        rb.velocity = direction * moveSpeed;
    }

    private void HandleGoal(GameObject goal)
    {
        bool isPlayerGoal = goal.CompareTag("PlayerGoal");
        gameManager.AddScore(!isPlayerGoal);
        ResetBall();
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        direction = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;
        moveSpeed = 8f;
        rb.velocity = direction * moveSpeed;
    }
}