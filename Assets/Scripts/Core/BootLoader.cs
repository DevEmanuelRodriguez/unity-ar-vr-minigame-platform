using UnityEngine;
using UnityEngine.SceneManagement;
/*
 Hacer que Boot cargue Menu automáticamente
 
 */
public class BootLoader : MonoBehaviour
{
    private void Start()
    {

        SceneManager.LoadScene("01_Menu");
    }
}
