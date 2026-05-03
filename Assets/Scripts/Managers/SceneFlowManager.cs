using UnityEngine;
using UnityEngine.SceneManagement;
/*
 SceneFlowManager gestiona escenas:
    carga siguiente minijuego
    vuelve al menú
    sigue el orden de scene list
 
 
 */
public class SceneFlowManager : MonoBehaviour
{
    public static SceneFlowManager Instance;

    private string[] scenes = {
        "02_HorseRunner",
        "03_Boat",
        "04_Submarine",
        "05_ARRace",
        "06_VRSpace",
        "07_Results"
    };

    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextScene()
    {
        if (currentIndex < scenes.Length)
        {
            SceneManager.LoadScene(scenes[currentIndex]);
            currentIndex++;
        }
    }

    public void LoadMenu()
    {
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.ResetScore();
        }

        SceneManager.LoadScene("01_Menu");
        currentIndex = 0;
    }
}
