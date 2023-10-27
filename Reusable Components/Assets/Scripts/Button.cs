using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    [SerializeField] private int _sceneIndex;

    public void ChangeScene()
    {
        SceneManager.LoadScene(_sceneIndex);
        Debug.Log("perss");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
    }
}
