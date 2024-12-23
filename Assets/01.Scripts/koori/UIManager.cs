using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject gameoverWindow;

    public void CanvasEnable(bool value)
    {
        canvas.enabled = value;
    }

    public void GameOverPopup(bool value)
    {
        gameoverWindow.SetActive(value);
    }
}
