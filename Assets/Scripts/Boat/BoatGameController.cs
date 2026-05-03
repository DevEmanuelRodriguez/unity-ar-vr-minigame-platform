using UnityEngine;
using TMPro;

public class BoatGameController : MonoBehaviour
{
    public float gameDuration = 100f;

    public DummyMinigame dummyMinigame;
    public IcebergSpawner spawner;
    public BoatController boat;

    public TMP_Text timerText;

    private float timeLeft;
    private bool gameEnded = false;

    void Start()
    {
        timeLeft = gameDuration;
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;

        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(timeLeft).ToString();
        }

        // Si sobrevive → gana
        if (timeLeft <= 0)
        {
            WinGame();
        }
    }

    public void LoseGame()
    {
        if (gameEnded) return;

        gameEnded = true;

        // detener juego
        spawner.CancelInvoke();
        boat.enabled = false;

        // no suma puntos
        dummyMinigame.pointsToAdd = 0;

        // pasar al siguiente minijuego
        dummyMinigame.FinishGame();
    }

    public void WinGame()
    {
        if (gameEnded) return;

        gameEnded = true;

        // detener juego
        spawner.CancelInvoke();
        boat.enabled = false;

        // pasar al siguiente minijuego
        dummyMinigame.FinishGame();
    }
}
