using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public void OpenGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
