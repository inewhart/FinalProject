using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void Controls()
    {
        SceneManager.LoadScene("Controls");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
