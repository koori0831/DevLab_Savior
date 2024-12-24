
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameOverUI gameOverUI;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }

    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        gameOverUI = FindAnyObjectByType<GameOverUI>();
        gameOverUI.gameObject.SetActive(false);
    }

    public void CanvasEnable(bool value)
    {
        
    }

    public void GameOverPopup(bool value)
    {
      gameOverUI.gameObject.SetActive(value);
      if (value)
        {
            gameOverUI.PopUp();
        }
    }
}
