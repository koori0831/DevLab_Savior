using DG.Tweening;
using UnityEngine;

public class EscUI : MonoBehaviour
{
    [SerializeField] private BoolEventChannelSO stopGameChannel;
    private RectTransform escPos;
    private CanvasGroup escAlpha;
    bool isOpen;


    private void Awake()
    {
        escPos = GetComponent<RectTransform>();
        escAlpha = GetComponent<CanvasGroup>();
        
    }

    public void OpenOrClose()
    {
        if (!isOpen)
        {
            stopGameChannel.RaiseEvent(true);
            escAlpha.DOFade(1, 0.5f);
            escPos.DOAnchorPosX(421, 0.7f).OnComplete(() => { isOpen = true; });
            
        }
        else
        {
            stopGameChannel.RaiseEvent(false);
            escPos.DOAnchorPosX(861, 0.7f).OnComplete(() => { isOpen = false; });
           
            escAlpha.DOFade(0, 0.5f);
           
        }
    }

    public void Resume()
    {
        OpenOrClose();
    }

    public void Quits()
    {
        FadeManager.Instance.FadeSceneChange("StartScene",1);
    }

}
