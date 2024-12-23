
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameOverUI gameOverUI;

    public void CanvasEnable(bool value)
    {
        
    }

    public void GameOverPopup(bool value)
    {
      if (value)
        {
            gameOverUI.PopUp();
        }
    }
}
