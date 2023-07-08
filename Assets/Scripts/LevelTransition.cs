using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public string levelName = "PleaseChangeMe";
    private string menuSceneName = "MainMenu";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
        }
    }

    public void manualLevelTransition()
    {
        SceneManager.LoadScene(levelName);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
