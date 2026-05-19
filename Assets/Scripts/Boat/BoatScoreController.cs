using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BoatScoreController : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;

    private bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;

    public IcebergSpawner spawner;
    public BoatController boat;

    void Start()
    {
        Time.timeScale = 1f;

        if (resultText != null)
        {
            resultText.gameObject
                .SetActive(false);
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            score +=
                Time.deltaTime *
                scoreSpeed;

            int displayScore =
                Mathf.FloorToInt(score);

            if (scoreText != null)
            {
                scoreText.text =
                    "Score: "
                    + displayScore;
            }

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

        // campaña
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .AddScore(finalScore);
        }

        ShowWin();

        StopGame();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 2f);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        int finalScore =
            Mathf.RoundToInt(score);

        finalScore =
            Mathf.Clamp(
                finalScore,
                0,
                100
            );

        Debug.Log(
            "GAME OVER - Score: "
            + finalScore
        );

        // campaña
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .AddScore(finalScore);
        }

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
        Time.timeScale = 1f;

        // individual
        if (!GameManager.Instance.isCampaignMode)
        {
            SceneManager.LoadScene(
                "01_Menu"
            );

            return;
        }

        // campaña
        SceneFlowManager.Instance
            .LoadNextScene();
    }

    public void ShowGameOver()
    {
        if (resultText != null)
        {
            resultText.gameObject
                .SetActive(true);

            resultText.text =
                "GAME OVER";
        }
    }

    public void ShowWin()
    {
        if (resultText != null)
        {
            resultText.gameObject
                .SetActive(true);

            resultText.text =
                "YOU WIN";
        }
    }
}