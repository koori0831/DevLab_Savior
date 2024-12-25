using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void StartGame()
    {
        FadeManager.Instance.FadeSceneChange("MainGame", 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
