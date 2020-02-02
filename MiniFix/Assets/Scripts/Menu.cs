﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject menu;
    public GameObject firstSelectedObj;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StartMenu", 7.25f);
    }

    public void StartMenu()
    {
        menu.SetActive(true);
    }

    public void LoadNewGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        GameObject.Find ("EventSystem").GetComponent<EventSystem>().SetSelectedGameObject(firstSelectedObj, null);
    }

    public void QuitGame()
    {
        Application.Quit();
    } 
}
