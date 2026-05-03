using TMPro;
using UnityEngine;

public class BoatScoreController : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f; // puntos por segundo

    private bool isGameOver = false;

    public TextMeshProUGUI scoreText;   // Score: 45
    public TextMeshProUGUI resultText;  // YOU WIN / GAME OVER

    public IcebergSpawner spawner;
    public BoatController boat;

    void Start()
    {
        Time.timeScale = 1f;

        // ocultar texto de resultado al inicio
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime * scoreSpeed;

            int displayScore = Mathf.FloorToInt(score);

            // mostrar score
            if (scoreText != null)
            {
                scoreText.text = "Score: " + displayScore;
            }

            // victoria
            if (score >= 100f)
            {
                Win();
            }
        }
    }

    void Win()
    {
        if (isGameOver) return;

        isGameOver = true;

        Debug.Log("YOU WIN");

        int finalScore = 100;

        ScoreManager.Instance.AddScore(finalScore);

        ShowWin();

        // detener juego
        StopGame();

        // ralentizar (opcional)
        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 2f);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        int finalScore = Mathf.RoundToInt(score);
        finalScore = Mathf.Clamp(finalScore, 0, 100);

        Debug.Log("GAME OVER - Score: " + finalScore);

        ScoreManager.Instance.AddScore(finalScore);

        ShowGameOver();

        StopGame();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 2f);
    }

    void StopGame()
    {
        if (spawner != null)
        {
            spawner.CancelInvoke();
        }

        if (boat != null)
        {
            boat.enabled = false;
        }
    }

    void LoadNext()
    {
        SceneFlowManager.Instance.LoadNextScene();
    }

    public void ShowGameOver()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "GAME OVER";
    }

    public void ShowWin()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "YOU WIN";
    }
}