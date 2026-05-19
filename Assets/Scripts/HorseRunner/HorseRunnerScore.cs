using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
    mientras el juego está activo, suma puntos con el tiempo
    cuando hay game over, para el contador
    convierte el score en entero
    lo manda al ScoreManager global
*/

public class HorseRunnerScore : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;

    private bool isGameOver = false;

    public TextMeshProUGUI resultText;

    void Start()
    {
        Time.timeScale = 1f;
        ObstacleMove.globalSpeed = 3f;

        if (resultText != null)
        {
            resultText.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (!isGameOver)
        {
            score +=
                Time.deltaTime *
                scoreSpeed;

            if (score >= 100f)
            {
                Win();
            }
        }
    }

    void Win()
    {
        if (isGameOver)
        {
            return;
        }

        isGameOver = true;

        Debug.Log(
            "WIN - score máximo alcanzado"
        );

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
        {
            return;
        }

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