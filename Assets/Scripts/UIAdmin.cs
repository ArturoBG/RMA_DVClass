using UnityEngine.SceneManagement;
using UnityEngine;

public class UIAdmin : MonoBehaviour
{
    public void LoadScene(string level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
