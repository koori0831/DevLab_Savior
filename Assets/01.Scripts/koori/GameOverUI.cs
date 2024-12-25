using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private RectTransform retry;
    [SerializeField] private RectTransform menu;
    private RectTransform gameoverWindow;
    private CanvasGroup gameoverAlpha;


    private void Awake()
    {
        gameoverWindow = GetComponent<RectTransform>();
        gameoverAlpha = gameoverWindow.GetComponent<CanvasGroup>();
    }
    public void GameOver()
    {
       FadeManager.Instance.FadeSceneChange(SceneManager.GetActiveScene().name,1);
    }
    public void MainMenu()
    {
        FadeManager.Instance.FadeSceneChange("StartScene", 1);
    }

    public void PopUp()
    {
      
        gameoverWindow.gameObject.SetActive(true);

        gameoverWindow.DOScale(Vector2.one, 0.7f);
        gameoverWindow.DOMoveY(0, 0.6f);

        gameoverAlpha.DOFade(1, 0.5f).OnComplete(() =>
        {

            retry.DOScaleY(0.93f, 0.15f);
            menu.DOScaleY(0.93f, 0.15f).SetDelay(0.1f);

        });
    }

}
