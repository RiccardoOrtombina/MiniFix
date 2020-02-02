using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneManager : MonoBehaviour
{
    bool isGamePaused = false;
    public GameObject pauseMenu;
    public GameObject firstSelectedObj;
    public void RepeatScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    public void PauseGame()
    {
        if (!isGamePaused)
        {
            isGamePaused = true;
            pauseMenu.SetActive(true);
            GameObject.Find("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstSelectedObj, null);
            Time.timeScale = 0f;
        }
        else
        {
            isGamePaused = false;
            Time.timeScale = 1f;
            pauseMenu.SetActive(false);
        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
