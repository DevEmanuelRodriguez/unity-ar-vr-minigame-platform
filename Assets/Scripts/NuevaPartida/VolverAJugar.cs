using UnityEngine;
using UnityEngine.SceneManagement;

public class VolverAJugar : MonoBehaviour

{
    public void VolverABoot()
    {
        if (SceneFlowManager.Instance != null)
        {
            SceneFlowManager.Instance.LoadMenu();
        }
        else {
            SceneManager.LoadScene("00_Boot");
        }
    }
}
