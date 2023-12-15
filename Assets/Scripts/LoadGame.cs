using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    public void PlayGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenChestButton()
    {
        SceneManager.LoadScene(3);
    }
    public void ToLeaderBoard()
    {
        SceneManager.LoadScene(4);
    }
    public void ToMyBird()
    {
        SceneManager.LoadScene(5);
    }
}
