using UnityEngine;
using UnityEngine.SceneManagement;

public class Nav : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Spac");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
