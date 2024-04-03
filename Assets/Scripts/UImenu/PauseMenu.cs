using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour, IMenuui
{
    public void ExitGame()
    {
        SceneManager.LoadScene(0);
    }
}
