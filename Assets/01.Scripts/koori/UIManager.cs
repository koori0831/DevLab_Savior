
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private GameOverUI gameOverUI;
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
    }
    private void Start()
    {
        gameOverUI.PopUp();
    }

    private void OnSceneLoad(Scene arg0, LoadSceneMode arg1)
    {
        gameOverUI = FindAnyObjectByType<GameOverUI>();
        if (gameOverUI == null) return;
        gameOverUI.gameObject.SetActive(false);
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
