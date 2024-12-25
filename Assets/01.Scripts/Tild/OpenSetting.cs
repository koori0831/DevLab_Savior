using UnityEngine;
using DG.Tweening;

public class OpenSetting : MonoBehaviour
{
    [SerializeField] private CanvasGroup _open;
    [SerializeField] private CanvasGroup _close;
    [SerializeField] private GameObject _panel;

    public bool isClose;
    
    public void Change()
    {
        if (!isClose)
            _panel.SetActive(!isClose);
        _close.DOFade(0, 1).OnComplete(() => { _open.DOFade(1, 1).SetDelay(0.3f).OnComplete(() => _panel.SetActive(!isClose)); });
    }
}
