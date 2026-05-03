using TMPro;
using UnityEngine;

public class SubmarineScoreController : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;

    private bool isGameOver = false;
    public SubmarineController submarine;

    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;

    void Start()
    {
        Time.timeScale = 1f;

        if (resultText != null)
            resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver)
        {
            score += Time.deltaTime * scoreSpeed;

            int displayScore = Mathf.FloorToInt(score);

            if (scoreText != null)
            {
                scoreText.text = "Score: " + displayScore;
            }

            // CONDICIÓN DE VICTORIA
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

        int finalScore = 100;

        Debug.Log("YOU WIN");

        // AÑADIR AL SCORE GLOBAL
        ScoreManager.Instance.AddScore(finalScore);

        ShowResult("YOU WIN");

        StopGame();

        Time.timeScale = 0.2f;

        Invoke(nameof(LoadNext), 2f);
    }

    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;

        int finalScore = Mathf.FloorToInt(score);

        Debug.Log("GAME OVER - Score: " + finalScore);

        ScoreManager.Instance.AddScore(finalScore);

        ShowResult("GAME OVER");

        StopGame();

        Time.timeScale = 0.2f;

        Invoke(nameof(LoadNext), 2f);
    }

    void StopGame()
    {
        if (submarine != null)
        {
            submarine.enabled = false;
        }
    }

    void ShowResult(string text)
    {
        if (resultText != null)
        {
            resultText.gameObject.SetActive(true);
            resultText.text = text;
        }
    }

    void LoadNext()
    {
        SceneFlowManager.Instance.LoadNextScene();
    }
}