using TMPro;
using UnityEngine;

public class ARRaceGameManager : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;

    private bool isGameOver = false;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI resultText;

    private bool isGameStarted = false;

    void Start()
    {
        Time.timeScale = 1f;

        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver && isGameStarted)
        {
            score += Time.deltaTime * scoreSpeed;

            int displayScore = Mathf.FloorToInt(score);

            if (scoreText != null)
            {
                scoreText.text = "Score: " + displayScore;
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
        if (isGameOver) return;

        isGameOver = true;

        int finalScore = Mathf.Clamp(Mathf.RoundToInt(score), 0, 100);

        ScoreManager.Instance.AddScore(finalScore);

        ShowGameOver();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 2f);
    }

    void Win()
    {
        if (isGameOver) return;

        isGameOver = true;

        ScoreManager.Instance.AddScore(100);

        ShowWin();

        Time.timeScale = 0.5f;

        Invoke(nameof(LoadNext), 2f);
    }

    void LoadNext()
    {
        Time.timeScale = 1f;

        SceneFlowManager.Instance.LoadNextScene();
    }

    void ShowGameOver()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "GAME OVER";
    }

    void ShowWin()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "YOU WIN";
    }
}
