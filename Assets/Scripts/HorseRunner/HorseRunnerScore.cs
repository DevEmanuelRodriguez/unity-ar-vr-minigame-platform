using TMPro;
using UnityEngine;
/*
    mientras el juego está activo, suma puntos con el tiempo
    cuando hay game over, para el contador
    convierte el score en entero
    lo manda al ScoreManager global 
 */

public class HorseRunnerScore : MonoBehaviour
{
    public float score = 0f;
    public float scoreSpeed = 1f;//los puntos que se ganan por segundo
    private bool isGameOver = false;
    public TextMeshProUGUI resultText;

    void Start()
    {
        Time.timeScale = 1f; // resetea velocidad del juego
        ObstacleMove.globalSpeed = 3f;//6

        // oculta texto al inicio
        resultText.gameObject.SetActive(false);
    }

    void Update()
    {
        /*
         Time.deltaTime: es el tiempo real que ha pasado entre frames
         Ej: si el juego va a 60 FPS entonces deltaTime ≈ 0.016
         */
        if (!isGameOver)
        {
            score += Time.deltaTime * scoreSpeed;

            // detectar victoria
            if (score >= 100f)
            {
                Win();
            }
        }
    }

    void Win()
    {
        if (isGameOver) { 
            return; 
        }

        isGameOver = true;

        Debug.Log("WIN - score máximo alcanzado");

        int finalScore = 100;

        ScoreManager.Instance.AddScore(finalScore);

        /*// esperar 1 segundo antes de cambiar escena
        Invoke(nameof(LoadNext), 1f);*/

        // Mostrar mensaje
        ShowWin();

        // Ralentizar juego
        Time.timeScale = 0.2f;//0.5

        // Esperar y cambiar escena
        Invoke(nameof(LoadNext), 1f);

    }

    public void GameOver()
    {
        if (isGameOver) { 
            return;  
        }

        isGameOver = true;

        int finalScore = Mathf.RoundToInt(score);
        finalScore = Mathf.Clamp(finalScore, 0, 100);

        Debug.Log("GAME OVER - Score: " + finalScore);

        ScoreManager.Instance.AddScore(finalScore);

        /*// esperar 1 segundo antes de cambiar escena
        Invoke(nameof(LoadNext), 1f);*/

        // Mostrar mensaje
        ShowGameOver();

        // Ralentizar juego
        Time.timeScale = 0.2f;//0.5

        // Esperar y cambiar escena
        Invoke(nameof(LoadNext), 1f);
    }

    //retardo al cambiar de escena 
    void LoadNext()
    {
        SceneFlowManager.Instance.LoadNextScene();
    }

    public void ShowGameOver()
    {
        resultText.gameObject.SetActive(true);        
        resultText.text = "GAME OVER";
        //resultText.color = Color.red;   // game over
    }

    public void ShowWin()
    {
        resultText.gameObject.SetActive(true);
        resultText.text = "YOU WIN";
        //resultText.color = Color.green; // win
        
    }
}
