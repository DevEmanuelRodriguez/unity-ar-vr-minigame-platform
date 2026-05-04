using UnityEngine;
using System.Collections;

public class SubmarineController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float jumpForce = 6f;

    [Header("Water Physics")]
    [SerializeField] private float fallMultiplier = 1.5f;

    private Rigidbody2D rb;
    private SubmarineScoreController scoreController;

    [Header("Audio")]
    [SerializeField] private AudioSource hitAudio;
    [SerializeField] private AudioClip hitSound;

    private bool isGameOver = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        scoreController = FindObjectOfType<SubmarineScoreController>();

        if (hitAudio == null)
            hitAudio = GetComponent<AudioSource>();
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
            StartCoroutine(GameOverRoutine());
        }
    }

    IEnumerator GameOverRoutine()
    {
        isGameOver = true;

        Debug.Log("GAME OVER");

        //  SONIDO
        if (hitAudio != null && hitSound != null)
        {
            hitAudio.PlayOneShot(hitSound);
        }

        //  MICRO FREEZE (impacto)
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.05f);

        // Volver a velocidad lenta
        Time.timeScale = 0.2f;

        // Esperar 1 frame para asegurar audio
        yield return null;

        rb.linearVelocity = Vector2.zero;

        if (scoreController != null)
        {
            scoreController.GameOver();
        }
    }
}