using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private RectTransform retry;
    [SerializeField] private RectTransform menu;
    private RectTransform gameoverWindow;
    private CanvasGroup gameoverAlpha;
    public UnityEvent onGameOver;
    private void Awake()
    {
        gameoverWindow = GetComponent<RectTransform>();
        gameoverAlpha = gameoverWindow.GetComponent<CanvasGroup>();
    }
    public void GameOver()
    {
       FadeManager.Instance.FadeSceneChange(SceneManager.GetActiveScene(),1);
    }
    public void MainMenu()
    {
        FadeManager.Instance.FadeSceneChange(SceneManager.GetSceneByName("Tild"), 1);
    }

    public void PopUp()
    {
       onGameOver.Invoke();
      
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
