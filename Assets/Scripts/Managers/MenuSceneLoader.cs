using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneLoader : MonoBehaviour
{
    // Campaña completa
    public void PlayCampaign()
    {
        GameManager.Instance
            .isCampaignMode = true;

        // reset score
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .ResetScore();
        }

        SceneManager.LoadScene(
            "02_HorseRunner"
        );
    }

    // Minijuegos individuales
    public void PlayHorse()
    {
        GameManager.Instance
            .isCampaignMode = false;

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .ResetScore();
        }

        SceneManager.LoadScene(
            "02_HorseRunner"
        );
    }

    public void PlayBoat()
    {
        GameManager.Instance
            .isCampaignMode = false;

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .ResetScore();
        }

        SceneManager.LoadScene(
            "03_Boat"
        );
    }

    public void PlaySubmarine()
    {
        GameManager.Instance
            .isCampaignMode = false;

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .ResetScore();
        }

        SceneManager.LoadScene(
            "04_Submarine"
        );
    }

    public void PlayARRace()
    {
        GameManager.Instance
            .isCampaignMode = false;

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .ResetScore();
        }

        SceneManager.LoadScene(
            "05_ARRace"
        );
    }

    public void PlayVR()
    {
        GameManager.Instance
            .isCampaignMode = false;

        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance
                .ResetScore();
        }

        SceneManager.LoadScene(
            "06_VRSpace"
        );
    }
}