using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour, IMenuui
{
    public void PlayerGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}