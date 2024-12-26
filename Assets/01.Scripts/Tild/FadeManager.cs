using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoSingleton<FadeManager>
{
    private Image fadeImage;


    private void Awake()
    {
        fadeImage = GetComponent<Image>();
    }
    private void Start()
    {
        FadeOut(1);
    }

    public void Fade(float time, bool autoEnd)
    {
        fadeImage.DOFade(1, time).OnComplete(() =>
        {
            if (!autoEnd)
                return;

            fadeImage.DOFade(0, time).SetDelay(0.3f);


        });


    }
    public void FadeOut(float time)
    {
        fadeImage.DOFade(0, time);
    }

    public void FadeSceneChange(string SceneName, float time)
    {
        fadeImage.DOFade(1, time).OnComplete(() =>
        {
            SceneManager.LoadScene(SceneName);
        });
    }
}
