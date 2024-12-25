using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    public void StartGame()
    {
        FadeManager.Instance.FadeSceneChange("MainScene", 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
