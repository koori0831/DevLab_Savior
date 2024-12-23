using UnityEngine;
using DG.Tweening;

public class OpenSetting : MonoBehaviour
{
    [SerializeField] private CanvasGroup _open;
    [SerializeField] private CanvasGroup _close;
    
    public void Change()
    {
        _close.DOFade(0, 1).OnComplete(() => { _open.DOFade(1, 1).SetDelay(0.3f); });
        
    }
}
