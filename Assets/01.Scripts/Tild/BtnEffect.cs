using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
using Ami.BroAudio;

public class BtnEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
{
    private TMP_Text _text;
    private Vector2 scaleTemp;
    private Vector2 scaledScaleTemp;
    private SoundSource hoverSound;

    private void Awake()
    {
        hoverSound = GetComponent<SoundSource>();
        _text = GetComponentInChildren<TMP_Text>();
        scaleTemp = _text.transform.localScale;
        scaledScaleTemp = scaleTemp * 0.92f;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        hoverSound.Play();  
        _text.transform.DORotate(new Vector3(0, 0, 5), 0.4f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {

        _text.transform.DORotate(new Vector3(0, 0, 0), 0.4f);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _text.transform.DOScale(scaleTemp, 0.2f).SetEase(Ease.OutSine);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _text.transform.DOScale(scaledScaleTemp, 0.2f).SetEase(Ease.InSine);
    }
}
