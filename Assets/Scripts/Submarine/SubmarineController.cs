using UnityEngine;

public class SubmarineController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce = 6f;

    [Header("Water Physics")]
    [SerializeField] private float fallMultiplier = 1.5f;

    private Rigidbody2D rb;
    private SubmarineScoreController scoreController;

    private bool isGameOver = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        scoreController = FindObjectOfType<SubmarineScoreController>();
    }

    void Update()
    {
        if (isGameOver) return;

        HandleInput();
        ApplyBetterFall();
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
    }

    void ApplyBetterFall()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        Debug.Log("GAME OVER");

        rb.linearVelocity = Vector2.zero;

        // 🔥 Llamar al sistema de score (que gestiona UI + escena)
        if (scoreController != null)
        {
            scoreController.GameOver();
        }
    }
}