using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ARRaceGameManager : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;

    private bool isGameOver = false;
    private bool isGameStarted = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;

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
        if (!isGameOver &&
            isGameStarted)
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

    public void StartGame()
    {
        isGameStarted = true;
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        int finalScore =
            Mathf.Clamp(
                Mathf.RoundToInt(score),
                0,
                100
            );

        // campaña
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .AddScore(finalScore);
        }

        ShowGameOver();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 2f);
    }

    void Win()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        // campaña
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .AddScore(100);
        }

        ShowWin();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 2f);
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

    void ShowGameOver()
    {
        if (resultText != null)
        {
            resultText.gameObject
                .SetActive(true);

            resultText.text =
                "GAME OVER";
        }
    }

    void ShowWin()
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