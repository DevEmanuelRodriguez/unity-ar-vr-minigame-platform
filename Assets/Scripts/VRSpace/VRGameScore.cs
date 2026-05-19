using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VRGameScore : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;

    private bool isGameOver = false;

    [Header("UI")]
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

        if (scoreText != null)
        {
            scoreText.text =
                "Score: 0";
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
        if (isGameOver)
            return;

        isGameOver = true;

        Debug.Log("VR WIN");

        int finalScore = 100;

        // campaña
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .AddScore(finalScore);
        }

        ShowWin();

        Time.timeScale = 0.2f;

        Invoke(nameof(LoadNext), 1f);
    }

    public void GameOver()
    {
        if (isGameOver)
            return;

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
            "VR GAME OVER - Score: "
            + finalScore
        );

        // campaña
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .AddScore(finalScore);
        }

        ShowGameOver();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 1f);
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