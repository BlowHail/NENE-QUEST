using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class menu : MonoBehaviour
{
    public Image win;
    public GameObject pausemenu;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseMenu()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void Continue()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1;
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
