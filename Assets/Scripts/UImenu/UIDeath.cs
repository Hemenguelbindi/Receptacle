using UnityEngine;
using UnityEngine.SceneManagement;

public class UIDeath : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void BackMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
