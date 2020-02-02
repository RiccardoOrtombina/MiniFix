using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    bool isGamePaused = false;
    public void RepeatScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        if(!isGamePaused)
        {
            Time.timeScale = 0;
            isGamePaused = true;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
